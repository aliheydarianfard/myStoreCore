using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using QRCoder;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;

namespace Utilities
{
    public static class Tools
    {
        #region RetrieveErrorMessage
        public static string RetrieveErrorMessage(Exception ex)
        {
            var message = "";
            message += ex.Message + Environment.NewLine;
            message += ((ex.InnerException != null) ? ex.InnerException.Message + Environment.NewLine : "");
            message += ((ex.InnerException != null && ex.InnerException.InnerException != null) ? ex.InnerException.InnerException.Message : "");

            return message;
        }
        #endregion

        #region ConvertGregorianDateToPersianDate
        public static string ConvertGregorianDateToPersianDate(DateTime dateTime)
        {
            try
            {
                var pc = new PersianCalendar();
                return $"{pc.GetYear(dateTime)}/{pc.GetMonth(dateTime):00}/{pc.GetDayOfMonth(dateTime):00}";
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region ConvertPersianDateToGregorianDate
        public static DateTime ConvertPersianDateToGregorianDate(string Date, bool IsMin = true)
        {
            //year   month day.
            //#### / ## / ##.
            //0123 4 56 7 89.
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("En");
            DateTime date1 = System.DateTime.Now;
            if (Date != null && Date.Trim().Length == 10)
            {
                int day = Convert.ToInt32(Date[8].ToString() + Date[9].ToString());
                int Month = Convert.ToInt32(Date[5].ToString() + Date[6].ToString());
                int Year = Convert.ToInt32(Date[0].ToString() + Date[1].ToString() + Date[2].ToString() + Date[3].ToString());
                try
                {
                    //DateConvert.tnDateTime tndt = new DateConvert.tnDateTime(Year, Month, day);
                    //DateTime date = DateConvert.tnDateTime.tnShamsiToGregorian(tndt);
                    DateTime date = new DateTime(Year, Month, day, IsMin ? 0 : 23, IsMin ? 0 : 59, IsMin ? 0 : 59, new System.Globalization.PersianCalendar());
                    return date;
                }
                catch (Exception ex)
                {
                    //CreateErrorLog(ex);
                    return date1;
                }
            }
            else
                return date1;
        }
        #endregion

        #region DateTitle
        public static string DateTitle(string FromDate, string ToDate, bool xIsMirror = false)
        {
            if (FromDate == ToDate && FromDate.Trim() != "" && FromDate.Trim() != "/  /")
            {
                if (xIsMirror)
                    return "مورخه " + FromDate;
                else
                    return "مورخه " + PrintableDate(FromDate);
            }
            else
            {
                if (xIsMirror)
                    return "از تاريخ " + ((FromDate.Trim() == "/  /" || FromDate.Trim() == "") ? "0000/00/00" : FromDate) + " الي " + ((ToDate.Trim() == "/  /" || ToDate.Trim() == "") ? "9999/99/99" : ToDate);
                else
                    return "از تاريخ " + PrintableDate((FromDate.Trim() == "/  /" || FromDate.Trim() == "") ? "0000/00/00" : FromDate) + " الي " + PrintableDate((ToDate.Trim() == "/  /" || ToDate.Trim() == "") ? "9999/99/99" : ToDate);
            }
        }
        #endregion

        #region PrintableDate
        private static string PrintableDate(string Date)
        {
            if (Date.Trim().Length != 10)
                return Date;
            return (Date.Substring(8, 2) + "/" + Date.Substring(5, 2) + "/" + Date.Substring(0, 4));
        }
        #endregion

        #region GetNewGUID
        public static string GetNewGUID()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
        #endregion

        #region CreateQRCode
        public static string CreateQRCode(string qrText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            return "data:image/png;base64," + BitmapToBase64(qrCodeImage);
            //return BitmapToBytes(qrCodeImage);
        }
        #endregion

        #region BitmapToBytes
        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        #endregion

        #region BitmapToBase64
        private static string BitmapToBase64(Bitmap img)
        {
            return Convert.ToBase64String(BitmapToBytes(img));
        }
        #endregion

        #region CreateSMSVerifyCode
        public static string CreateSMSVerifyCode()
        {
            return new Random().Next(1000, 9999).ToString();
        }
        #endregion

        #region WriteImage
        public static string WriteImage(string img, string path, string oldFileName = null)
        {
            if (string.IsNullOrEmpty(img))
                return null;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (img.StartsWith("data:image", true, null))
                img = img.Substring(img.IndexOf("base64") + 7);
            var bytes = Convert.FromBase64String(img);
            string fileName = !string.IsNullOrEmpty(oldFileName) ? oldFileName : Tools.GetNewGUID() + ".jpg";
            var imgPath = path + fileName;
            using (var imageFile = new FileStream(imgPath, FileMode.Create))
            {
                imageFile.Write(bytes, 0, bytes.Length);
                imageFile.Flush();
            }
            return fileName;
        }
        #endregion

        #region HashPassword
        public static string HashPassword(string password, byte[] salt = null, bool needsOnlyHash = false)
        {
            if (salt == null || salt.Length != 16)
            {
                // generate a 128-bit salt using a secure PRNG
                salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            if (needsOnlyHash) return hashed;
            // password will be concatenated with salt using ':'
            return $"{hashed}:{Convert.ToBase64String(salt)}";
        }
        #endregion

        #region VerifyPassword
        public static bool VerifyPassword(string hashedPasswordWithSalt, string passwordToCheck)
        {
            // retrieve both salt and password from 'hashedPasswordWithSalt'
            var passwordAndHash = hashedPasswordWithSalt.Split(':');
            if (passwordAndHash == null || passwordAndHash.Length != 2)
                return false;
            var salt = Convert.FromBase64String(passwordAndHash[1]);
            if (salt == null)
                return false;
            // hash the given password
            var hashOfpasswordToCheck = HashPassword(passwordToCheck, salt, true);
            // compare both hashes
            if (String.Compare(passwordAndHash[0], hashOfpasswordToCheck) == 0)
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}

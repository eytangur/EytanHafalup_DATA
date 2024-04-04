using ExampleProject.MyServiceReference;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ExampleProject
{
    class UserDetailsValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is User user))
                return null;
            else
                return string.Format("{0} {1}, phone:{2}", user.LastName, user.FirstName, user.Phone);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class BirthdayValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateTime bDay))
                return null;
            else
                return string.Format("{0}", bDay.ToShortDateString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                DateTime bDay = DateTime.Parse(value.ToString());
                return bDay;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
    public sealed class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                                object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            string fileName = (string)value;
            if (fileName == "") return null;

            string path = System.IO.Path.Combine(ImageUtils.ImageDirectory, fileName);

            try
            {
                Uri uri = new Uri(fileName);
                fileName = uri.Segments[uri.Segments.Length - 1];
                path = System.IO.Path.Combine(ImageUtils.ImageDirectory, fileName);

                if (!File.Exists(path))
                {
                    DownloadImageFromWeb(uri, path);
                }
            }
            catch
            {
                if (!File.Exists(path))
                {
                    GetImageFromService(fileName, path);
                }
            }
            // finally
            return new BitmapImage(new Uri(path));
        }

        private void GetImageFromService(string fileName, string localFilePath)
        {
            ServiceClient service = new ServiceClient();
            byte[] imageArray= service.GetIamge(fileName);
            MemoryStream stream = new MemoryStream(imageArray);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            img.Save(localFilePath);
        }

        private void DownloadImageFromWeb(Uri uri, string localFilePath)
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                using (Stream stream = webClient.OpenRead(uri))
                {
                    using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(stream))
                    {
                        stream.Flush();
                        stream.Close();
                        bitmap.Save(localFilePath);
                    }
                }
            }
        }

        public object ConvertBack(object value, Type targetType,
                                    object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

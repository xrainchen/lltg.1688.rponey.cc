using System.IO;

namespace Rponey.AlbbSDK.Utilty
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 根据完整文件路径获取FileStream
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static FileStream GetFileStream(string fileName)
        {
            FileStream fileStream = null;
            if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
            {
                fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            }
            return fileStream;
        }
        /// <summary>
        /// 获取文件内容
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileContent(string fileName)
        {
            //todo:文件缓存依赖
            return File.ReadAllText(fileName);
        }
        ///// <summary>
        ///// 从Url下载文件
        ///// </summary>
        ///// <param name="url"></param>
        ///// <param name="fullFilePathAndName"></param>
        //public static void DownLoadFileFromUrl(string url, string fullFilePathAndName)
        //{
        //    using (FileStream fs = new FileStream(fullFilePathAndName, FileMode.OpenOrCreate))
        //    {
        //        HttpUtility.Get.Download(url, fs);
        //        fs.Flush(true);
        //    }
        //}
    }
}

// DataOperation.cs

using System.Text;
using System.IO;
using System.IO.Compression;

namespace KYapp.Builate
{
    /// <summary>
    /// デフレートアルゴリズムを使用したデータ圧縮・解凍機能を定義します。
    /// </summary>
    public static class DataOperation
    {
        /// <summary>
        /// 文字列を圧縮しバイナリ列として返します。
        /// </summary>
        public static byte[] CompressFromStr(string message) => Compress(Encoding.UTF8.GetBytes(message));

        /// <summary>
        /// バイナリを圧縮します。
        /// </summary>
        public static byte[] Compress(byte[] src)
        {
            using (var ms = new MemoryStream())
            {
                using (var ds = new DeflateStream(ms, CompressionMode.Compress, true/*msは*/))
                {
                    ds.Write(src, 0, src.Length);
                }

                // 圧縮した内容をbyte配列にして取り出す
                ms.Position = 0;
                byte[] comp = new byte[ms.Length];
                ms.Read(comp, 0, comp.Length);
                return comp;
            }
        }

        /// <summary>
        /// 圧縮データを文字列として復元します。
        /// </summary>
        public static string DecompressToStr(byte[] src) => Encoding.UTF8.GetString(Decompress(src));

        /// <summary>
        /// 圧縮済みのバイト列を解凍します。
        /// </summary>
        public static byte[] Decompress(byte[] src)
        {
            using (var ms = new MemoryStream(src))
            using (var ds = new DeflateStream(ms, CompressionMode.Decompress))
            {
                using (var dest = new MemoryStream())
                {
                    ds.CopyTo(dest);

                    dest.Position = 0;
                    byte[] decomp = new byte[dest.Length];
                    dest.Read(decomp, 0, decomp.Length);
                    return decomp;
                }
            }
        }
    }
}
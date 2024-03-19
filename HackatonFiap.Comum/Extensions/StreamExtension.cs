using System.Text;

namespace HackatonFiap.Comum.Extensions
{
    public static class StreamExtension
    {
        public static byte[] ToByteArray(this Stream sm)
        {
            if (sm.Position != 0)
            {
                sm.Position = 0;
            }
            
            using var ms = new MemoryStream();
            sm.CopyTo(ms);
            return ms.ToArray();
        }
        
        public static async Task<byte[]> ToByteArrayAsync(this Stream sm)
        {
            if (sm.Position != 0)
            {
                sm.Position = 0;
            }

            using var ms = new MemoryStream();
            await sm.CopyToAsync(ms);
            return ms.ToArray();
        }
        
        public static async Task<string> ToStringAsync(this Stream sm)
        {
            byte[] biteArray;
            await using (var memoryStream = new MemoryStream())
            {
                await sm.CopyToAsync(memoryStream);
                biteArray = memoryStream.ToArray();
            }
            return Encoding.UTF8.GetString(biteArray);
        }
    }
}
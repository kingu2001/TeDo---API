using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace HashCertificate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var certPath = @"C:\Users\mikke\Desktop\TeDo\TeDo---API\SigningService\HashCertificate\HashCertificate\cert.pfx";

            var StaticPass = "12345";

            var PassToByte = Encoding.ASCII.GetBytes(StaticPass);

            var StaticPassHash = SHA256.HashData(PassToByte);

            Console.WriteLine("Write you password for the certificate");
            var answer = Console.ReadLine();

            var Pass = Encoding.ASCII.GetBytes(answer);

            byte[] PassHash = SHA256.HashData(Pass);
            
            bool AreEqual = StaticPassHash.SequenceEqual(PassHash);
            if (AreEqual)
            {
                X509Certificate2 cert = new X509Certificate2(certPath,answer);

                new X509Certificate2(certPath,answer);
                cert.GetRawCertData();
                
                Console.WriteLine(cert);
            }
            

            Console.ReadLine();
        }
    }
}

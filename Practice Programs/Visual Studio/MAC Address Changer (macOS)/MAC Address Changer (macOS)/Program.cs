using System.Diagnostics;

namespace MAC_Address_Changer__macOS_;

class Program
{
    static void Main(string[] args)
    {
        string code = "networksetup -setairportpower en0 off";

        var startInfo = new System.Diagnostics.ProcessStartInfo
        {
            WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
            FileName = "/bin/bash",
            Arguments = " -c \"" + code + " \""
        };
        process.StartInfo = startInfo;
        process.Start();
    }
}


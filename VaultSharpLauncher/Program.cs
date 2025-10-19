using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Trigger the initialization URI
        Process.Start(new ProcessStartInfo
        {
            FileName = "vaultbridge://system/integrations/openmainview",
            UseShellExecute = true
        });
    }
}
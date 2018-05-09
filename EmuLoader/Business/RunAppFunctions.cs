using EmuLoader.Classes;
using System;
using System.Diagnostics;

namespace EmuLoader.Business
{
    public static class RunAppFunctions
    {
        public static void OpenApplication(Rom rom)
        {
            string exe = rom.UseAlternateEmulator ? rom.Platform.EmulatorExeAlt : rom.Platform.EmulatorExe;
            string command = rom.UseAlternateEmulator ? rom.Platform.CommandAlt : rom.Platform.Command;

            if (!string.IsNullOrEmpty(rom.EmulatorExe) && !string.IsNullOrEmpty(rom.Command))
            {
                exe = rom.EmulatorExe;
                command = rom.Command;
            }

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = exe,
                    Arguments = command.Replace("%EMUPATH%", "")
                        .Replace("%ROMPATH%", "\"" + rom.Path + "\"")
                        .Replace("%ROMNAME%", RomFunctions.GetFileNameNoExtension(rom.Path))
                        .Replace("%ROMFILE%", RomFunctions.GetFileName(rom.Path)),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WorkingDirectory = rom.Platform.EmulatorExe.Substring(0, rom.Platform.EmulatorExe.LastIndexOf("\\"))
                }
            };

            proc.Start();
        }

        public static void OpenApplicationByCMD(Rom rom)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(@"cmd.exe");
            Process p = new Process();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            string arguments = rom.Platform.Command.Replace("%EMUPATH%", "\"" + rom.Platform.EmulatorExe + "\"")
                .Replace("%ROMPATH%", "\"" + rom.Path + "\"")
                .Replace("%ROMNAME%", RomFunctions.GetFileNameNoExtension(rom.Path))
                .Replace("%ROMFILE%", RomFunctions.GetFileName(rom.Path));

            startInfo.Arguments = arguments;
            p = Process.Start(startInfo);
        }

        public static void OpenApplicationByCMDWriteLine(Rom rom)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(@"cmd.exe");
            Process p = new Process();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            p = Process.Start(startInfo);

            string path = rom.Platform.Command.Replace("%EMUPATH%", "\"" + rom.Platform.EmulatorExe + "\"")
                .Replace("%ROMPATH%", "\"" + rom.Path + "\"")
                .Replace("%ROMNAME%", RomFunctions.GetFileNameNoExtension(rom.Path))
                .Replace("%ROMFILE%", RomFunctions.GetFileName(rom.Path));

            p.StandardInput.WriteLine(path);
            p.StandardInput.WriteLine("exit");
        }

        public static void OpenApplicationByCMDWriteLineCD(Rom rom)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("CMD.exe");
            Process p = new Process();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardInput = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            p = Process.Start(startInfo);

            string changeDir = "cd " + RomFunctions.GetRomDirectory(rom.Platform.EmulatorExe);
            string exe = rom.Platform.EmulatorExe.Remove(0, rom.Platform.EmulatorExe.LastIndexOf("\\") + 1);
            string path = rom.Platform.Command.Replace("%EMUPATH%", "\"" + exe + "\"")
                .Replace("%ROMPATH%", "\"" + rom.Path + "\"")
                .Replace("%ROMNAME%", RomFunctions.GetFileNameNoExtension(rom.Path))
                .Replace("%ROMFILE%", RomFunctions.GetFileName(rom.Path));

            p.StandardInput.WriteLine(changeDir);
            p.StandardInput.WriteLine(path);
            p.StandardInput.WriteLine("exit");
        }

        public static void OpenApplication(Platform platform)
        {
            string exe = platform.EmulatorExe;

            ProcessStartInfo startInfo = new ProcessStartInfo(exe);
            Process p = new Process();

            p = Process.Start(startInfo);
        }

        public static void OpenApplicationByCMDWriteLine(Platform platform)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("CMD.exe");
            Process p = new Process();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardInput = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            p = Process.Start(startInfo);

            string changeDir = "cd " + RomFunctions.GetRomDirectory(platform.EmulatorExe);
            string exe = platform.EmulatorExe.Remove(0, platform.EmulatorExe.LastIndexOf("\\") + 1);
            string path = "\"" + exe + "\"";

            p.StandardInput.WriteLine(changeDir);
            p.StandardInput.WriteLine(path);
            p.StandardInput.WriteLine("exit");
        }

        public static void RunPlatform(Rom rom)
        {
            if (rom.Platform == null)
            {
                throw new Exception("There ins't a platform associated to this ROM.");
            }

            OpenApplication(rom);
        }

        public static void RunPlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new Exception("Cannot open.");
            }

            OpenApplication(platform);
        }

    }
}

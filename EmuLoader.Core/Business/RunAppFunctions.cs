using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace EmuLoader.Core.Business
{
    public static class RunAppFunctions
    {
        public static void OpenApplication(Rom rom)
        {
            if (rom.Platform.Emulators == null || rom.Platform.Emulators.Count == 0)
            {
                return;
            }

            var emu = rom.Platform.Emulators[0];

            if (!string.IsNullOrEmpty(rom.Platform.DefaultEmulator))
            {
                var defaultEmu = rom.Platform.Emulators.FirstOrDefault(x => x.Name == rom.Platform.DefaultEmulator);

                if (defaultEmu != null)
                {
                    emu = defaultEmu;
                }
                else
                {
                    emu = rom.Platform.Emulators[0];
                }
            }
            else
            {
                emu = rom.Platform.Emulators[0];
            }

            if (!string.IsNullOrEmpty(rom.Emulator))
            {
                var defaultEmu = rom.Platform.Emulators.FirstOrDefault(x => x.Name == rom.Emulator);

                if (defaultEmu != null)
                {
                    emu = defaultEmu;
                }
            }

            string exe = emu.Path;
            string command = emu.Command;
            var index = emu.Path.LastIndexOf("\\");
            string workdir = index == -1 ? "" : emu.Path.Substring(0, emu.Path.LastIndexOf("\\"));

            string args = command.Replace("%EMUPATH%", "")
                        .Replace("%ROMPATH%", "\"" + rom.Platform.DefaultRomPath + "\\" + rom.FileName + "\"")
                        .Replace("%ROMNAME%", rom.FileNameNoExt)
                        .Replace("%ROMFILE%", rom.FileName);

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = exe,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WorkingDirectory = workdir
                }
            };

            proc.Start();
        }
        
        public static void OpenApplication(Rom rom, Emulator emu)
        {
            string exe = emu.Path;
            string command = emu.Command;
            var index = emu.Path.LastIndexOf("\\");
            string workdir = index == -1 ? "" : emu.Path.Substring(0, emu.Path.LastIndexOf("\\"));

            string args = command.Replace("%EMUPATH%", "")
                        .Replace("%ROMPATH%", "\"" + rom.Platform.DefaultRomPath + "\\" + rom.FileName + "\"")
                        .Replace("%ROMNAME%", rom.FileNameNoExt)
                        .Replace("%ROMFILE%", rom.FileName);

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = exe,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WorkingDirectory = workdir
                }
            };

            proc.Start();
        }

        public static void OpenApplicationByCMD(Rom rom)
        {
            if (rom.Platform.Emulators == null || rom.Platform.Emulators.Count == 0)
            {
                return;
            }

            var emu = rom.Platform.Emulators[0];

            if (!string.IsNullOrEmpty(rom.Platform.DefaultEmulator))
            {
                var defaultEmu = rom.Platform.Emulators.FirstOrDefault(x => x.Name == rom.Platform.DefaultEmulator);

                if (defaultEmu != null)
                {
                    emu = defaultEmu;
                }
            }

            ProcessStartInfo startInfo = new ProcessStartInfo(@"cmd.exe");
            Process p = new Process();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            string arguments = emu.Command.Replace("%EMUPATH%", "\"" + emu.Path + "\"")
                .Replace("%ROMPATH%", "\"" + rom.Platform.DefaultRomPath + "\\" + rom.FileName + "\"")
                .Replace("%ROMNAME%", rom.FileNameNoExt)
                .Replace("%ROMFILE%", rom.FileName);

            startInfo.Arguments = arguments;
            p = Process.Start(startInfo);
        }

        public static void OpenApplicationByCMDWriteLine(Rom rom)
        {
            if (rom.Platform.Emulators == null || rom.Platform.Emulators.Count == 0)
            {
                return;
            }

            var emu = rom.Platform.Emulators[0];

            if (!string.IsNullOrEmpty(rom.Platform.DefaultEmulator))
            {
                var defaultEmu = rom.Platform.Emulators.FirstOrDefault(x => x.Name == rom.Platform.DefaultEmulator);

                if (defaultEmu != null)
                {
                    emu = defaultEmu;
                }
            }

            ProcessStartInfo startInfo = new ProcessStartInfo(@"cmd.exe");
            Process p = new Process();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            p = Process.Start(startInfo);

            string path = emu.Command.Replace("%EMUPATH%", "\"" + emu.Path + "\"")
                .Replace("%ROMPATH%", "\"" + rom.Platform.DefaultRomPath + "\\" + rom.FileName + "\"")
                .Replace("%ROMNAME%", rom.FileNameNoExt)
                .Replace("%ROMFILE%", rom.FileName);

            p.StandardInput.WriteLine(path);
            p.StandardInput.WriteLine("exit");
        }

        public static void OpenApplicationByCMDWriteLineCD(Rom rom)
        {
            if (rom.Platform.Emulators == null || rom.Platform.Emulators.Count == 0)
            {
                return;
            }

            var emu = rom.Platform.Emulators[0];

            if (!string.IsNullOrEmpty(rom.Platform.DefaultEmulator))
            {
                var defaultEmu = rom.Platform.Emulators.FirstOrDefault(x => x.Name == rom.Platform.DefaultEmulator);

                if (defaultEmu != null)
                {
                    emu = defaultEmu;
                }
            }

            ProcessStartInfo startInfo = new ProcessStartInfo("CMD.exe");
            Process p = new Process();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardInput = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            p = Process.Start(startInfo);

            string changeDir = "cd " + RomFunctions.GetRomDirectory(emu.Path);
            string exe = emu.Path.Remove(0, emu.Path.LastIndexOf("\\") + 1);
            string path = emu.Command.Replace("%EMUPATH%", "\"" + exe + "\"")
                .Replace("%ROMPATH%", "\"" + rom.Platform.DefaultRomPath + "\\" + rom.FileName + "\"")
                .Replace("%ROMNAME%", rom.FileNameNoExt)
                .Replace("%ROMFILE%", rom.FileName);

            p.StandardInput.WriteLine(changeDir);
            p.StandardInput.WriteLine(path);
            p.StandardInput.WriteLine("exit");
        }

        public static void OpenApplication(Platform platform)
        {
            if (platform.Emulators == null || platform.Emulators.Count == 0)
            {
                return;
            }

            var emu = platform.Emulators[0];

            if (!string.IsNullOrEmpty(platform.DefaultEmulator))
            {
                var defaultEmu = platform.Emulators.FirstOrDefault(x => x.Name == platform.DefaultEmulator);

                if (defaultEmu != null)
                {
                    emu = defaultEmu;
                }
            }

            string exe = emu.Path;

            ProcessStartInfo startInfo = new ProcessStartInfo(exe);
            Process p = new Process();

            p = Process.Start(startInfo);
        }

        public static void OpenApplicationByCMDWriteLine(Platform platform)
        {
            if (platform.Emulators == null || platform.Emulators.Count == 0)
            {
                return;
            }

            var emu = platform.Emulators[0];

            if (!string.IsNullOrEmpty(platform.DefaultEmulator))
            {
                var defaultEmu = platform.Emulators.FirstOrDefault(x => x.Name == platform.DefaultEmulator);

                if (defaultEmu != null)
                {
                    emu = defaultEmu;
                }
            }

            ProcessStartInfo startInfo = new ProcessStartInfo("CMD.exe");
            Process p = new Process();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardInput = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            p = Process.Start(startInfo);

            string changeDir = "cd " + RomFunctions.GetRomDirectory(emu.Path);
            string exe = emu.Path.Remove(0, emu.Path.LastIndexOf("\\") + 1);
            string path = "\"" + exe + "\"";

            p.StandardInput.WriteLine(changeDir);
            p.StandardInput.WriteLine(path);
            p.StandardInput.WriteLine("exit");
        }

        public static void RunPlatform(Rom rom)
        {
            if (rom.Platform == null)
            {
                throw new Exception("There isn't a platform associated to this ROM.");
            }

            OpenApplication(rom);
        }

        public static void RunPlatform(Emulator emulator)
        {
            if (string.IsNullOrEmpty(emulator.Name))
            {
                throw new Exception("There isn't a emulator setup.");
            }


            string exe = emulator.Path;
            var index = emulator.Path.LastIndexOf("\\");
            string workdir = index == -1 ? "" : emulator.Path.Substring(0, emulator.Path.LastIndexOf("\\"));

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = exe,
                    Arguments = "",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WorkingDirectory = workdir
                }
            };

            proc.Start();
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

﻿using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Lsj.Util
{
    /// <summary>
    /// Process Standard IO Redirector
    /// </summary>
    public class ProcessStandardIORedirector
    {
        private Process _process;
        private StreamWriter _input;
        private StreamReader _output;

        /// <summary>
        /// Start Process
        /// </summary>
        /// <param name="filename"></param>
        public void StartProcess(string filename)
        {
            if (_process != null && !_process.HasExited)
            {
                throw new InvalidOperationException($"Process has started. Process ID: {_process.Id}");
            }
            var startInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                FileName = filename,
            };
            _process = Process.Start(startInfo);
            _input = _process.StandardInput;
            _output = _process.StandardOutput;
        }

        /// <summary>
        /// Kill Process
        /// </summary>
        public void KillProcess()
        {
            if (_process == null)
            {
                throw new InvalidOperationException($"Process has not started");
            }
            if (_process.HasExited)
            {
                throw new InvalidOperationException($"Process has exited.");
            }
            _process.Kill();
        }

        /// <summary>
        /// Write Line To Standard Input
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public async Task WriteLine(string line)
        {
            if (_process == null)
            {
                throw new InvalidOperationException($"Process has not started");
            }
            if (!_process.HasExited)
            {
                await _input.WriteLineAsync(line);
            }
            else
            {
                throw new InvalidOperationException($"Process has exited. Exit code: {_process.ExitCode}");
            }
        }

        /// <summary>
        /// Read Line To Standard Ouput
        /// </summary>
        /// <returns></returns>
        public async Task<string> Readline()
        {
            if (_process == null)
            {
                throw new InvalidOperationException($"Process has not started");
            }
            if (!_process.HasExited)
            {
                return await _output.ReadLineAsync();
            }
            else
            {
                throw new InvalidOperationException($"Process has exited. Exit code: {_process.ExitCode}");
            }
        }
    }
}

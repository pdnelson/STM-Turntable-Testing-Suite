using StmTestingSuite.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;

namespace StmTestingSuite
{
    internal class TrackSelectTabMonitor(
        Form mainForm,
        StmConnector conn,

        // Buttons
        Button btnSendAndScan,

        // Data grid views
        DataGridView dgvProfile,
        DataGridView dgvPlaylist,

        // Progress bars
        ProgressBar prgCurrentTrack,
        ProgressBar prgPlaylist)
    {
        Form Form { get; } = mainForm;
        StmConnector Conn { get; } = conn;

        // Buttons
        Button BtnSendAndScan { get; } = btnSendAndScan;

        // Data grid views
        DataGridView DgvProfile { get; } = dgvProfile;
        DataGridView DgvPlaylist { get; } = dgvPlaylist;

        // Progress bars
        ProgressBar PrgCurrentTrack { get; } = prgCurrentTrack;
        ProgressBar PrgPlaylist { get; } = prgPlaylist;

        public bool Running { get; set; } = false;

        public void Start()
        {
            var dataCommand = new CmdGetProfilePlaylist(Conn, null);
            Running = true;

            Task monitoringTask = new(async () =>
            {
                while(Running)
                {
                    CmdGetProfilePlaylist.Response? data = await dataCommand.ExecuteWithResult();

                    if(data != null)
                    {
                        UpdateUserInterface((CmdGetProfilePlaylist.Response)data);
                    }

                    await Task.Delay(Constants.TrackSelectTabDataPollMs);
                }
            });

            monitoringTask.Start();
        }

        public void Stop()
        {
            Running = false;
        }

        private void UpdateUserInterface(CmdGetProfilePlaylist.Response data)
        {
            Utilities.WriteToUiFromThread(Form, () =>
            {
                // If the counts are different, then the track listing has changed, and we need to update the whole thing
                if(DgvProfile.Rows.Count != data.NormalizedProfile.Length)
                {
                    // Set profile
                    DgvProfile.Rows.Clear();

                    for (ushort i = 0; i < data.NormalizedProfile.Length; i++)
                    {
                        if (i == data.NormalizedProfile.Length - 1)
                        {
                            DgvProfile.Rows.Add(data.NormalizedProfile[i], "N/A", $"Record End");
                        }
                        else
                        {
                            var track = i + 1;
                            DgvProfile.Rows.Add(data.NormalizedProfile[i], track, $"Track #{track}");
                        }
                    }
                }
                // Otherwise, we can just update each row with what is there. Only the position can possibly change
                else
                {

                    for (ushort i = 0; i < data.NormalizedProfile.Length; i++)
                    {
                        DgvProfile.Rows[i].Cells[0].Value = data.NormalizedProfile[i].ToString();
                        DgvProfile.UpdateCellValue(0, i);
                    }
                }
            });
        }
    }
}

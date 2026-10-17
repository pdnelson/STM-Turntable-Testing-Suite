using StmTestingSuite.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

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
        ProgressBar prgPlaylist,
        
        // Labels
        Label lblNowPlaying)
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

        Label LblNowPlaying { get; } = lblNowPlaying;

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
                // POPULATING THE RECORD PROFILE IS HERE!!!

                // If the counts are different, then the track listing has changed, and we need to update the whole thing
                if(DgvProfile.Rows.Count != data.NormalizedProfile.Length)
                {
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

                        if(i != data.NormalizedProfile.Length - 1)
                        {
                            bool onTrack = data.CurrentPosition >= data.NormalizedProfile[i] && data.CurrentPosition < data.NormalizedProfile[i + 1];

                            if (onTrack)
                            {
                                DgvProfile.Rows[i].DefaultCellStyle.BackColor = Color.Coral;
                            }
                            else
                            {
                                DgvProfile.Rows[i].DefaultCellStyle.BackColor = Color.White;
                            }
                        }
                    }
                }

                // POPULATING THE PLAYLIST IS HERE!!!

                // If the counts are different, then the track listing has changed, and we need to update the whole thing
                if (DgvPlaylist.Rows.Count != data.Playlist.Length)
                {
                    DgvPlaylist.Rows.Clear();

                    for(ushort i = 0; i < data.Playlist.Length; i++)
                    {
                        var profileTrack = data.Playlist[i];
                        var trackNumber = DgvProfile.Rows[profileTrack].Cells[1].Value;
                        var trackName = DgvProfile.Rows[profileTrack].Cells[2].Value;

                        if(trackNumber != null && trackName != null)
                        {
                            DgvPlaylist.Rows.Add(i + 1, trackNumber, trackName);
                        }

                        if(data.CurrentPlaylistIndex == i)
                        {
                            DgvPlaylist.Rows[i].DefaultCellStyle.BackColor = Color.Teal;
                        }
                    }
                }
                else
                {
                    for (ushort i = 0; i < data.Playlist.Length; i++)
                    {
                        var profileTrack = data.Playlist[i];

                        DgvPlaylist.Rows[i].Cells[0].Value = i + 1;
                        DgvPlaylist.Rows[i].Cells[1].Value = DgvProfile.Rows[profileTrack].Cells[1].Value;
                        DgvPlaylist.Rows[i].Cells[2].Value = DgvProfile.Rows[profileTrack].Cells[2].Value;

                        if (data.CurrentPlaylistIndex == i)
                        {
                            DgvPlaylist.Rows[i].DefaultCellStyle.BackColor = Color.Coral;
                        } 
                        else
                        {
                            DgvPlaylist.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }

                        DgvProfile.UpdateCellValue(0, i);
                    }
                }

                // CALCULATING THE CURRENT PLAYING PROGRESS BAR IS HERE!
            });
        }
    }
}

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

        public bool Paused { get; set; } = false;

        public void Start()
        {
            var dataCommand = new CmdGetProfilePlaylist(Conn, null);
            Running = true;

            Task monitoringTask = new(async () =>
            {
                while(Running)
                {
                    if(!Paused)
                    {
                        CmdGetProfilePlaylist.Response? data = await dataCommand.ExecuteWithResult();

                        if (data != null)
                        {
                            UpdateUserInterface((CmdGetProfilePlaylist.Response)data);
                        }

                        await Task.Delay(Constants.TrackSelectTabDataPollMs);
                    }
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
                short onTrackProfileIndex = -1;

                // POPULATING THE RECORD PROFILE IS HERE!!!

                // If the counts are different, then the track listing has changed, and we need to update the whole thing
                if(DgvProfile.Rows.Count != data.NormalizedProfile.Length)
                {
                    DgvProfile.Rows.Clear();

                    if(data.NormalizedProfile.Length > 0)
                    {
                        for (ushort i = 0; i < data.NormalizedProfile.Length; i++)
                        {
                            if (i == data.NormalizedProfile.Length - 1)
                            {
                                DgvProfile.Rows.Add(data.NormalizedProfile[i], "N/A", "Record End");
                            }
                            else
                            {
                                var track = i + 1;
                                DgvProfile.Rows.Add(data.NormalizedProfile[i], track, $"Track #{track}");
                            }
                        }
                    }
                }
                // Otherwise, we can just update each row with what is there. Only the position can possibly change
                else
                {
                    bool isOnAnyTrack = false;
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
                                isOnAnyTrack = true;
                                onTrackProfileIndex = (short)i;
                            }
                            else
                            {
                                DgvProfile.Rows[i].DefaultCellStyle.BackColor = Color.White;
                            }
                        }
                    }

                    if(!isOnAnyTrack)
                    {
                        onTrackProfileIndex = -1;
                    }
                }

                // POPULATING THE PLAYLIST IS HERE!!!

                // If the counts are different, then the track listing has changed, and we need to update the whole thing
                if (DgvPlaylist.Rows.Count != data.Playlist.Length)
                {
                    DgvPlaylist.Rows.Clear();

                    int playlistProgressMax = 0;

                    if (data.Playlist.Length > 0)
                    {
                        for (ushort i = 0; i < data.Playlist.Length; i++)
                        {
                            var profileTrackIndex = data.Playlist[i];
                            var trackNumber = DgvProfile.Rows[profileTrackIndex].Cells[1].Value;
                            var trackName = DgvProfile.Rows[profileTrackIndex].Cells[2].Value;

                            if (trackNumber != null && trackName != null)
                            {
                                DgvPlaylist.Rows.Add(i + 1, trackNumber, trackName);
                            }

                            if (data.CurrentPlaylistIndex == i)
                            {
                                DgvPlaylist.Rows[i].DefaultCellStyle.BackColor = Color.Teal;
                            }

                            playlistProgressMax += TrackRangeByIndex(data.NormalizedProfile, profileTrackIndex);
                        }

                    }

                    PrgPlaylist.Maximum = playlistProgressMax;
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

                        DgvPlaylist.UpdateCellValue(0, i);
                    }
                }

                // CALCULATING THE CURRENT PLAYING PROGRESS BAR IS HERE!
                if(onTrackProfileIndex > -1)
                {
                    LblNowPlaying.Text = $"Now Playing: {DgvProfile.Rows[onTrackProfileIndex].Cells[2].Value}";

                    PrgCurrentTrack.Minimum = data.NormalizedProfile[onTrackProfileIndex];
                    PrgCurrentTrack.Maximum = data.NormalizedProfile[onTrackProfileIndex + 1];
                    PrgCurrentTrack.Value = data.CurrentPosition;
                } 
                else
                {
                    PrgCurrentTrack.Minimum = 0;
                    PrgCurrentTrack.Maximum = 10;
                    PrgCurrentTrack.Value = 0;

                    LblNowPlaying.Text = "Idle";
                }

                if(data.Playlist.Length > 0)
                {

                    // CALCULATING THE PLAYLIST PROGRESS BAR IS HERE!
                    int totalPlayedSoFar = 0;
                    for (int i = 0; i < data.CurrentPlaylistIndex; i++)
                    {
                        totalPlayedSoFar += TrackRangeByIndex(data.NormalizedProfile, data.Playlist[i]);
                    }

                    // This is different than the above calculation, because the above calculation COULD be a different track on the
                    // record than the current playlist item (if the user moves the tonearm).
                    int currentPlaylistTrackProgress = 0;
                    
                    if(data.CurrentPlaylistIndex > -1)
                    {
                        var profileIndex = data.Playlist[data.CurrentPlaylistIndex];

                        currentPlaylistTrackProgress = data.CurrentPosition - data.NormalizedProfile[profileIndex];

                        // If the toenarm somehow moved beyond the bounds of the playlist track, zero it out, because the user
                        // is moving it around manually, and the data is no longer useful.
                        if (currentPlaylistTrackProgress < 0)
                        {
                            currentPlaylistTrackProgress = 0;
                        }
                        else if (currentPlaylistTrackProgress > TrackRangeByIndex(data.NormalizedProfile, profileIndex))
                        {
                            currentPlaylistTrackProgress = 0;
                        }
                    }

                    PrgPlaylist.Value = totalPlayedSoFar + currentPlaylistTrackProgress;
                } else
                {
                    PrgPlaylist.Value = 0;
                }
            });
        }

        private ushort TrackRangeByIndex(ushort[] profile, ushort index)
        {
            return (ushort)(profile[index + 1] - profile[index]);
        }
    }
}

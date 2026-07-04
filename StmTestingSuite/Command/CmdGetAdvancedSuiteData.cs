using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace StmTestingSuite.Command
{
    internal class CmdGetAdvancedSuiteData(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;
        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_ADVANCED_SUITE_DATA;
        public override string Name => "Advanced Suite Data";
        public override ushort ResponseSize => 22;
        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            Response? response = null;
            string responseString = "";

            // Verify both the start and end key are intact. If they aren't, then throw out the whole response.
            if (rawData[0] == Constants.AdvancedDataStartKey && rawData[21] == Constants.AdvancedDataEndKey)
            {
                response = new Response(rawData);
                responseString = ((Response)response).ToString();
            }

            return new StmCommandResult<Response?>(response, responseString);
        }

        public async Task<Response?> ExecuteWithResult()
        {
            return ((StmCommandResult<Response?>?)Execute().Result)?.Result;
        }

        public struct Response
        {
            public Response(byte[] rawData)
            {
                byte[] verticalBytes = { rawData[1], rawData[2] };
                VerticalPosition = BitConverter.ToUInt16(verticalBytes);

                byte[] horizontalBytes = { rawData[3], rawData[4] };
                HorizontalPosition = BitConverter.ToUInt16(horizontalBytes);

                LiftStatus = (LiftStatus)rawData[5];
                HomeStatus = (HomeStatus)rawData[6];
                CommandId = (CommandId)rawData[7];
                SubCommandId = (SubCommandId)rawData[8];
                CommandStatus = (CommandStatus)rawData[9];

                byte[] upTimeBytes = { rawData[10], rawData[11], rawData[12], rawData[13] };
                UpTimeSeconds = BitConverter.ToUInt32(upTimeBytes);

                SpeedSetting = (SpeedOption)rawData[14];

                byte[] speedTargetBytes = { rawData[15], rawData[16], rawData[17], rawData[18] };
                SpeedTarget = BitConverter.ToSingle(speedTargetBytes);

                SizeSetting = (SizeOption)rawData[19];

                ClutchStatus = (ClutchStatus)rawData[20];
            }

            public ushort VerticalPosition { get; }
            public ushort HorizontalPosition { get; }
            public LiftStatus LiftStatus { get; }
            public HomeStatus HomeStatus { get; }
            public CommandId CommandId { get; }
            public SubCommandId SubCommandId { get; }
            public CommandStatus CommandStatus { get; }
            public uint UpTimeSeconds { get; }
            public SpeedOption SpeedSetting { get; }
            public float SpeedTarget { get; }
            public SizeOption SizeSetting { get; }
            public ClutchStatus ClutchStatus { get; }

            public readonly override string ToString()
            {
                return $"({VerticalPosition}, {HorizontalPosition}, {LiftStatus}, {HomeStatus}, {ClutchStatus}, {CommandId}, {SubCommandId}, {CommandStatus}, {UpTimeSeconds}, {SpeedSetting}, {SpeedTarget}, {SizeSetting})";
            }
        }
    }
}

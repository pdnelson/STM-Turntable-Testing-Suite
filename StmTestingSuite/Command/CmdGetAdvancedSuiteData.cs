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
        public override ushort ResponseSize => 19;
        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            var response = new Response(rawData);

            return new StmCommandResult<Response>(response, response.ToString());
        }

        public async Task<Response?> ExecuteWithResult()
        {
            return ((StmCommandResult<Response>?)Execute().Result)?.Result;
        }

        public struct Response
        {
            public Response(byte[] rawData)
            {
                byte[] verticalBytes = { rawData[0], rawData[1] };
                VerticalPosition = BitConverter.ToUInt16(verticalBytes);

                byte[] horizontalBytes = { rawData[2], rawData[3] };
                HorizontalPosition = BitConverter.ToUInt16(horizontalBytes);

                LiftStatus = (LiftStatus)rawData[4];
                HomeStatus = (HomeStatus)rawData[5];
                CommandId = (CommandId)rawData[6];
                SubCommandId = (SubCommandId)rawData[7];
                CommandStatus = (CommandStatus)rawData[8];

                byte[] upTimeBytes = { rawData[9], rawData[10], rawData[11], rawData[12] };
                UpTimeSeconds = BitConverter.ToUInt32(upTimeBytes);

                SpeedSetting = (SpeedOption)rawData[13];

                byte[] speedTargetBytes = { rawData[14], rawData[15], rawData[16], rawData[17] };
                SpeedTarget = BitConverter.ToSingle(speedTargetBytes);

                SizeSetting = (SizeOption)rawData[18];
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

            public readonly override string ToString()
            {
                return $"({VerticalPosition}, {HorizontalPosition}, {LiftStatus}, {HomeStatus}, {CommandId}, {SubCommandId}, {CommandStatus}, {UpTimeSeconds}, {SpeedSetting}, {SpeedTarget}, {SizeSetting})";
            }
        }
    }
}

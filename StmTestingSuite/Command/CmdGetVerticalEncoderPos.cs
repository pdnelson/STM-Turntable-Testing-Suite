using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace StmTestingSuite.Command
{
    internal class CmdGetVerticalEncoderPos(StmConnector conn) : BaseStmCommand(conn)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_VERTICAL_ENCODER_POS;

        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.NONE;

        public override string Name => "Vertical Encoder Position";

        public override ushort ResponseSize => 2;

        public override IStmCommandResult InterpretResponseData(byte[]? rawData)
        {
            if(rawData == null) return new StmCommandResult<UInt16?>(null, "");

            byte lsb = rawData[0];
            byte msb = rawData[1];

            UInt16 finalInt = (UInt16)(((UInt16)msb << 8) | (UInt16)lsb);

            return new StmCommandResult<UInt16>(finalInt, finalInt.ToString());
        }
    }
}

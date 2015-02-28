using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitchat.Socket
{
    class Opcodes
    {
        private const byte registration = 0x0A;
        private const byte registrationHandshake = 0x0B;
        private const byte registrationConfirmation = 0x0C;
        private const byte login = 0x0D;
        private const byte loginVerify = 0x0F;
        private const byte friendsListRequest = 0x10;
        private const byte friendsListConfirm = 0x11;
        private const byte addFriend = 0x12;
        private const byte openChat = 0x13;
        private const byte chatOpened = 0x14;
        private const byte message = 0x15;

        public Opcodes(byte opcode, string args)
        {
            switch (opcode)
            { 
                case registration:
                    break;
                case registrationHandshake:
                    break;
                case registrationConfirmation:
                    break;
                case login:
                    break;
                case loginVerify:
                    break;
                case friendsListRequest:
                    break;
                case friendsListConfirm:
                    break;
                case addFriend:
                    break;
                case openChat:
                    break;
                case chatOpened:
                    break;
                case message:
                    break;
                default:
                    break;
            }
        }
    }
}

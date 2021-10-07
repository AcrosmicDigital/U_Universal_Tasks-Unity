using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U.Universal.Tasks
{
    internal static class S
    {

        public static class Uidentity
        {
            /*
             * Creates a new Guid
             */
            public static Guid NewIdGuid()
            {
                return Guid.NewGuid();
            }

            /*
             * Creates a new 19 chars UInt64 Id
             */
            public static UInt64 NewIdLong()
            {

                byte[] buffer = NewIdGuid().ToByteArray();

                return BitConverter.ToUInt64(buffer, 0);

            }

            /*
             * Creates a new 10 chars UInt32 Id
             */
            public static UInt32 NewIdShort()
            {

                byte[] buffer = NewIdGuid().ToByteArray();

                UInt32 num = BitConverter.ToUInt32(buffer, 0);

                if (num < 1000000000)
                    num += 1000000000;

                return num;

            }

        }

    }

}

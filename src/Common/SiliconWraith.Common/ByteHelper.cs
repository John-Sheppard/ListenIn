using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibeTribe.Common
{
    public static class EncodingExtensions
    {
        
        /*
         *         GetBytesWithBom
         *                  This method gets the bytes of a string with a byte order mark.
         *                  
         *                  Parameters
         *                       enc: The encoding to use to get the bytes.
         *                       text: The string to get the bytes of.
         *                                
         *                  Returns
         *                       A byte array that is the result of getting the bytes of text with a byte order mark.
         *                       
         *                  Exceptions
         *                       ArgumentNullException: Thrown if enc or text is null.
         */


        public static byte[] GetBytesWithBom(this Encoding enc, string text)
        {
            ArgumentNullException.ThrowIfNull(enc);
            ArgumentNullException.ThrowIfNull(text);
            return enc.GetBytes(text).PrependByteOrderMark(enc);
        }
    }

    /*
     *     ByteHelperExtensions
     *         This class provides extension methods for byte arrays.
     *                 
     */
    public static class ByteHelperExtensions
    {
        /*
         *         AppendBytes
         *                  This method appends two byte arrays together.
         *                  
         *                  Parameters
         *                       b1: The first byte array to append.
         *                       b2: The second byte array to append.
         *                                
         *                  Returns
         *                       A new byte array that is the result of appending b1 and b2.
         *                       
         *                  Exceptions
         *                       ArgumentNullException: Thrown if b1 or b2 is null.
         */
        public static byte[] AppendBytes(this byte[] b1, byte[] b2)
        {
            ArgumentNullException.ThrowIfNull(b1);
            ArgumentNullException.ThrowIfNull(b2);

            byte[] appended = new byte[b1.Length + b2.Length];
            Buffer.BlockCopy(b1, 0, appended, 0, b1.Length);
            Buffer.BlockCopy(b2, 0, appended, b1.Length, b2.Length);
            return appended;
        }

        /*
         *         PrependByteOrderMark
         *                  This method prepends a byte order mark to a byte array.
         *                  
         *                  Parameters
         *                       data: The byte array to prepend the byte order mark to.
         *                       enc: The encoding to use to get the byte order mark.
         *                                
         *                  Returns
         *                       A new byte array that is the result of prepending the byte order mark to data.
         *                       
         *                  Exceptions
         *                       ArgumentNullException: Thrown if data or enc is null.
         */
        public static byte[] PrependByteOrderMark(this byte[] data, Encoding enc)
        {
            ArgumentNullException.ThrowIfNull(data);
            ArgumentNullException.ThrowIfNull(enc);

            return enc.GetPreamble().AppendBytes(data);
        }

        /*
         *         ToOrderedGuid
         *                  This method converts a byte array to a Guid using big endian.
         *                  
         *                  Parameters
         *                       data: The byte array to convert to a Guid.
         *                                
         *                  Returns
         *                       A Guid that is the result of converting data to a Guid using big endian.
         *                       
         *                  Exceptions
         *                       InvalidOperationException: Thrown if data is not 16 bytes in length.
         */
        public static Guid ToOrderedGuid(this byte[] data)
        {
            //
            // Default behavior passing byte array to Guid constructor uses little endian.
            //
            // Bytes=000102030405060708090A0B0C0D0E0F => Guid.ToString()="03020100-0504-0706-0809-0a0b0c0d0e0f"
            //
            if (data.Length != 16)
            {
                throw new InvalidOperationException("ToOrderedGuid only handles arrays that are 16 bytes in length.");
            }

            return new Guid(new[]
            {
                data[3],
                data[2],
                data[1],
                data[0],
                data[5],
                data[4],
                data[7],
                data[6],
                data[8],
                data[9],
                data[10],
                data[11],
                data[12],
                data[13],
                data[14],
                data[15]
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFServerWebAPI.ServiceModel.Encoder
{
    public static class EncodeHelper
    {
        public static string Encode(string plainMsg)
        {
            try
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainMsg);
                return System.Convert.ToBase64String(plainTextBytes);
            }
            catch (Exception ex) 
            {
                System.Diagnostics.Debug.WriteLine($"ENCODER:\tFAIL\tEncode. {ex.Message}");
                return string.Empty; 
            }
        }

        public static string Decode(string encodedMsg)
        {
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(encodedMsg);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch (Exception ex) 
            {
                System.Diagnostics.Debug.WriteLine($"ENCODER:\tFAIL\tDecode. {ex.Message}");
                return string.Empty; 
            }
        }
    }
}

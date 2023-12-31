using System.Text;
using Solana.Unity.Wallet;
using UnityEngine;

namespace SolPlay.Staking
{
    public class GemFarmPDAHelper
    {
        public static PublicKey FarmProgramm = new PublicKey(
            "farmL4xeBFVXJqtfxCzU9b28QACM7E2W2ctT6epAjvE"
        );

        public static PublicKey Farm = new PublicKey(
            "HBKYxnX9C98FNHqzXHzBiK7RW85bxmEoinVaMHmov3ac"
        );

        public static string RefreshFarmInstructionIdentifier = "global:refresh_farmer";
        
        public static PublicKey FindFarmerPDA(PublicKey walletPubKey, out byte farmerBump)
        {
            if (!PublicKey.TryFindProgramAddress(new[]
                    {
                        Encoding.UTF8.GetBytes("farmer"),
                        Farm.KeyBytes,
                        walletPubKey.KeyBytes
                    },
                    FarmProgramm,
                    out PublicKey farmAddress,
                    out farmerBump))
            {
                Debug.LogError("Could not find farmer address");
                return null;
            }

            return farmAddress;
        }        
        
        public static PublicKey FindFarmAuthorityPDA(out byte farmAuthBump)
        {
            if (!PublicKey.TryFindProgramAddress(new[]
                    {
                        Farm.KeyBytes
                    },
                    FarmProgramm,
                    out PublicKey farmAuth,
                    out farmAuthBump))
            {
                Debug.LogError("Could not find farmer address");
                return null;
            }

            return farmAuth;
        }
    }
}
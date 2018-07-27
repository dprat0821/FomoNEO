using System;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using Helper = Neo.SmartContract.Framework.Helper;
using System.Text;

using System.ComponentModel;
using System.Numerics;

namespace FOMO
{
	

	public class FOMO: SmartContract{


		public const int cdBlocks = 8640;
		public const string pxRound = "r";
		public const string roundkey = "nr";



		public static readonly byte[] Owner = "AK2nJJpJr6o664CWJKi1QRXjqeic2zRp8y".ToScriptHash();
        
		[Serializable]
		public class Round{
			public BigInteger endHeight;
			public BigInteger pool;

		}

		private static Round GetRound(BigInteger idRound){
			if( idRound >= numRounds()){
				return null;
			}
			else{
				byte[] data = Storage.Get(Storage.CurrentContext, pxRound + " " + idRound.ToString());
				return (Round)data.Deserialize();
			}
		}
        
		public static BigInteger numRounds(){
			return Storage.Get(Storage.CurrentContext, roundkey).AsBigInteger();
		}

		public static BigInteger remainTime (BigInteger idRound){
			Round round = GetRound(idRound);
			if(round != null){
				return Blockchain.GetHeight() - 
			}
			else{
				return -1;
			}
		}

		public static BigInteger boostrape(){
			
		}

        public static object main(string op, params object[] args)
        {
            if (Runtime.Trigger == TriggerType.Verification)
            {
                if (Owner.Length == 20)
                {
                    return Runtime.CheckWitness(Owner);
                }
                else if (Owner.Length == 33)
                {
                    byte[] signature = op.AsByteArray();
                    return VerifySignature(signature, Owner);
                }
                return true;
            }


        }
	}

}

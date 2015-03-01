using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bitchat.Encryption
{
    class BitDiffieHellmen
    {
        public ECDiffieHellmanCng ecdh;
        public byte[] publicKey { get; set; }
        public byte[] derivedKey { get; set; }

        // I do the changes

        public BitDiffieHellmen()
        {
            ecdh = new ECDiffieHellmanCng();
            generatePublicKey();
        }

        public void generatePublicKey()
        {
            ecdh.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
            ecdh.HashAlgorithm = CngAlgorithm.Sha256;
            publicKey = ecdh.PublicKey.ToByteArray();
        }
        public void generateDerviedKey(byte[] publicKey)
        {
            derivedKey = ecdh.DeriveKeyMaterial(CngKey.Import(publicKey, CngKeyBlobFormat.EccPublicBlob));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Engines;

namespace WebApplication1.util
{
    public class Utils
    {
        /// <summary>
        /// Método que encripta una cadena
        /// </summary>
        /// <param name=&quot;data&quot;></param>
        /// <returns></returns>
        public static string Encrypt(string data)
        {
            string key = "xeon1707";
            Encryptor<TwofishEngine>encrypt = new Encryptor<TwofishEngine>(Encoding.UTF8, System.Text.Encoding.ASCII.GetBytes(key));
            string cipher = encrypt.Encrypt(data);
            return cipher;
        }

        /// <summary>
        /// Método que desencripta una cadena
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Decrypt(string data)
        {
            if (data != null)
            {
                string key = "xeon1707";
                Encryptor<TwofishEngine> encrypt = new Encryptor<TwofishEngine>(Encoding.UTF8, System.Text.Encoding.ASCII.GetBytes(key));
                string plainText = encrypt.Decrypt(data);
                plainText = plainText.Replace("\0", "");
                return plainText;
            }
            else
            {
                return null;
            }
        }
    }

    public sealed class Encryptor<T> where T : IBlockCipher, new()
    {
        private readonly Encoding encoding;

    private readonly IBlockCipher blockCipher;

    private BufferedBlockCipher cipher;

    private ICipherParameters parameters;

    public Encryptor(Encoding encoding, byte[] key)
    {
        this.blockCipher = new CbcBlockCipher(new T());
        this.parameters = new KeyParameter(key);
        this.cipher = new BufferedBlockCipher(this.blockCipher);
        this.encoding = encoding;
    }

    public Encryptor(Encoding encoding, byte[] key, byte[] iv)
    {
        this.blockCipher = new CbcBlockCipher(new T());
        this.parameters = new ParametersWithIV(new KeyParameter(key), iv);
        this.cipher = new BufferedBlockCipher(this.blockCipher);
        this.encoding = encoding;
    }

    public string Encrypt(string plain)
    {
        byte[] input = this.encoding.GetBytes(plain);

        if ((input.Length % this.blockCipher.GetBlockSize())>0)
            {
            byte[] newResult = new byte[(input.Length + (this.blockCipher.GetBlockSize() - (input.Length % this.blockCipher.GetBlockSize())))];
            input.CopyTo(newResult, 0);
            input = newResult;
        }

        byte[] result = this.BouncyCastleCrypto(true, input);

        return Convert.ToBase64String(result);
    }

    public string Decrypt(string cipher)
    {
        byte[] result = this.BouncyCastleCrypto(false, Convert.FromBase64String(cipher));
        return this.encoding.GetString(result);
    }

    private byte[] BouncyCastleCrypto(bool forEncrypt, byte[] input)
    {
        try
        {
            this.cipher.Init(forEncrypt, this.parameters);

            return this.cipher.DoFinal(input);
        }
        catch (CryptoException)
        {
             throw;
        }
    }
}
}
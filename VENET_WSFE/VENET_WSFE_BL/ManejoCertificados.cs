namespace VENET_WSFE_BL
{
    using System;
    using System.Security.Cryptography.Pkcs;
    using System.Security.Cryptography.X509Certificates;

    public class CertificadosX509Lib
    {
        /// <summary> 
        /// Firma mensaje 
        /// </summary> 
        /// <param name="argBytesMsg">Bytes del mensaje</param> 
        /// <param name="argCertFirmante">Certificado usado para firmar</param> 
        /// <returns>Bytes del mensaje firmado</returns> 
        /// <remarks></remarks> 
        public static byte[] FirmaBytesMensaje(byte[] argBytesMsg, X509Certificate2 argCertFirmante)
        {
            try
            {
                // Pongo el mensaje en un objeto ContentInfo (requerido para construir el obj SignedCms) 
                ContentInfo infoContenido = new ContentInfo(argBytesMsg);
                SignedCms cmsFirmado = new SignedCms(infoContenido);

                // Creo objeto CmsSigner que tiene las caracteristicas del firmante 
                CmsSigner cmsFirmante = new CmsSigner(argCertFirmante);
                cmsFirmante.IncludeOption = X509IncludeOption.EndCertOnly;

                // Firmo el mensaje PKCS #7 
                cmsFirmado.ComputeSignature(cmsFirmante);

                // Encodeo el mensaje PKCS #7. 
                return cmsFirmado.Encode();
            }
            catch (Exception excepcionAlFirmar)
            {
                throw new Exception("Error al firmar: " + excepcionAlFirmar.Message);
            }
        }

        /// <summary> 
        /// Lee certificado de disco 
        /// </summary> 
        /// <param name="argArchivo">Ruta del certificado a leer.</param> 
        /// <param name="argClave">Clave del certificado a leer.</param>
        /// <returns>Un objeto certificado X509</returns> 
        /// <remarks></remarks> 
        public static X509Certificate2 ObtieneCertificadoDesdeArchivo(string argArchivo, string argClave)
        {
            X509Certificate2 objCert = new X509Certificate2();

            try
            {
                objCert.Import(Microsoft.VisualBasic.FileIO.FileSystem.ReadAllBytes(argArchivo), argClave, new X509KeyStorageFlags());
                return objCert;
            }
            catch (Exception excepcionAlImportarCertificado)
            {
                throw new Exception("argArchivo=" + argArchivo + " excepcion=" + excepcionAlImportarCertificado.Message + " " + excepcionAlImportarCertificado.StackTrace);
            }
        }

    }
}


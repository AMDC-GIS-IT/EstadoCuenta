using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aestadodecuenta : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("AriesCustom", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Clave");
            if ( ! entryPointCalled )
            {
               AV13Clave = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aestadodecuenta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public aestadodecuenta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_Clave )
      {
         this.AV13Clave = aP0_Clave;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_Clave )
      {
         this.AV13Clave = aP0_Clave;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName(AV61Ruta);
         setOutputType("pdf");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 12269, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            AV23Fecha3 = DateTimeUtil.ResetTime(DateTimeUtil.Now( context));
            AV55Hora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            /* Using cursor P000E2 */
            pr_default.execute(0, new Object[] {AV13Clave});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A6CLAVES_RUTASRUTA = P000E2_A6CLAVES_RUTASRUTA[0];
               n6CLAVES_RUTASRUTA = P000E2_n6CLAVES_RUTASRUTA[0];
               A7UMAPS = P000E2_A7UMAPS[0];
               n7UMAPS = P000E2_n7UMAPS[0];
               A1CLAVE_CATASTRAL = P000E2_A1CLAVE_CATASTRAL[0];
               AV15count = (short)(AV15count+1);
               AV64UMAPS = (long)(Math.Round(A7UMAPS, 18, MidpointRounding.ToEven));
               AV53ART_ID_DOC = A1CLAVE_CATASTRAL;
               /* Using cursor P000E3 */
               pr_default.execute(1, new Object[] {AV53ART_ID_DOC});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A2ART_ID_DOC = P000E3_A2ART_ID_DOC[0];
                  A10NOMBRE = P000E3_A10NOMBRE[0];
                  A9ACT_ID_CARD = P000E3_A9ACT_ID_CARD[0];
                  A12NOMBRE_COLONIA = P000E3_A12NOMBRE_COLONIA[0];
                  n12NOMBRE_COLONIA = P000E3_n12NOMBRE_COLONIA[0];
                  AV35Nombre = A10NOMBRE;
                  AV10ACT_ID_CARD = A9ACT_ID_CARD;
                  AV53ART_ID_DOC = A2ART_ID_DOC;
                  AV63NOMBRE_COLONIA = A12NOMBRE_COLONIA;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
               H0E0( false, 299) ;
               getPrinter().GxAttris("Arial", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nombre:", 25, Gx_line+183, 92, Gx_line+205, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 20, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Alcaldía Municipal del Distrito Cental", 108, Gx_line+17, 683, Gx_line+67, 1, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35Nombre, "")), 92, Gx_line+183, 425, Gx_line+205, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10ACT_ID_CARD, "")), 100, Gx_line+217, 300, Gx_line+239, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53ART_ID_DOC, "")), 408, Gx_line+217, 558, Gx_line+239, 0, 0, 0, 1) ;
               getPrinter().GxDrawBitMap(context.GetImagePath( "95130b7a-b128-4e54-8298-646ac84013e4", "", context.GetTheme( )), 683, Gx_line+0, 816, Gx_line+67) ;
               getPrinter().GxDrawBitMap(context.GetImagePath( "eda46848-09cd-492f-abad-525fdafedf51", "", context.GetTheme( )), 17, Gx_line+0, 109, Gx_line+83) ;
               getPrinter().GxAttris("Arial", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tegucigalpa, Honduras", 108, Gx_line+50, 683, Gx_line+100, 1, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 11, true, false, false, false, 0, 128, 128, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("GERENCIA DE RECAUDACIÓN Y CONTROL FINANCIERO", 108, Gx_line+80, 683, Gx_line+130, 1, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("ESTADO DE CUENTA ", 108, Gx_line+130, 683, Gx_line+163, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Arial", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha:", 492, Gx_line+183, 542, Gx_line+205, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV23Fecha3, "99/99/9999"), 542, Gx_line+183, 642, Gx_line+205, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Identidad:", 25, Gx_line+217, 100, Gx_line+239, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Clave Catastral:", 300, Gx_line+217, 408, Gx_line+239, 0, 0, 0, 1) ;
               getPrinter().GxDrawRect(8, Gx_line+267, 808, Gx_line+298, 1, 0, 0, 0, 1, 92, 206, 223, 0, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Año", 8, Gx_line+267, 91, Gx_line+298, 1, 0, 0, 1) ;
               getPrinter().GxDrawLine(92, Gx_line+267, 92, Gx_line+298, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(217, Gx_line+267, 217, Gx_line+298, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Impuesto", 92, Gx_line+267, 217, Gx_line+298, 1, 0, 0, 1) ;
               getPrinter().GxDrawLine(367, Gx_line+267, 367, Gx_line+298, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Tren de Aseo", 217, Gx_line+267, 367, Gx_line+298, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Tasa de Bomberos", 367, Gx_line+267, 534, Gx_line+298, 1, 0, 0, 1) ;
               getPrinter().GxDrawLine(533, Gx_line+267, 533, Gx_line+298, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Recargos", 533, Gx_line+267, 666, Gx_line+298, 1, 0, 0, 1) ;
               getPrinter().GxDrawLine(667, Gx_line+267, 667, Gx_line+298, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Total", 667, Gx_line+267, 809, Gx_line+298, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Hora:", 650, Gx_line+183, 700, Gx_line+205, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV55Hora, "99:99:99"), 692, Gx_line+183, 784, Gx_line+205, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Colonia:", 542, Gx_line+217, 600, Gx_line+239, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63NOMBRE_COLONIA, "")), 608, Gx_line+217, 791, Gx_line+239, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV64UMAPS), "ZZZZZZZZZZZ-ZZZ-ZZZ9")), 717, Gx_line+67, 840, Gx_line+84, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigó UMAPS:", 625, Gx_line+67, 717, Gx_line+89, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63NOMBRE_COLONIA, "")), 683, Gx_line+83, 808, Gx_line+105, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Colonia:", 625, Gx_line+83, 683, Gx_line+105, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Ruta:", 625, Gx_line+100, 683, Gx_line+122, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV13Clave), "ZZZZZZZZZZZZZZZZZ9")), 683, Gx_line+100, 808, Gx_line+122, 0, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+299);
               AV26Impuestostot = 0;
               AV52TrenDeAseotot = 0;
               AV43TasaBomberostot = 0;
               AV31Interestot = 0;
               AV49Totaltot = 0;
               AV62Anio23 = (short)(DateTimeUtil.Year( DateTimeUtil.AddYr( DateTimeUtil.Now( context), -9)));
               AV18Count5 = AV62Anio23;
               while ( AV18Count5 <= 2024 )
               {
                  AV12Anio2 = AV18Count5;
                  AV11Anio = AV12Anio2;
                  AV21Fecha = context.localUtil.YMDToD( AV12Anio2, 8, 31);
                  AV30Interes3 = 0;
                  AV25Impuestos1 = 0;
                  AV42TasaBomberos1 = 0;
                  AV51TrenDeAseo1 = 0;
                  AV48Total1 = 0;
                  /* Using cursor P000E4 */
                  pr_default.execute(2, new Object[] {AV53ART_ID_DOC, AV11Anio});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A13OBL_YEAR = P000E4_A13OBL_YEAR[0];
                     n13OBL_YEAR = P000E4_n13OBL_YEAR[0];
                     A2ART_ID_DOC = P000E4_A2ART_ID_DOC[0];
                     A15IMPUESTO = P000E4_A15IMPUESTO[0];
                     n15IMPUESTO = P000E4_n15IMPUESTO[0];
                     A17TASA_BOMBEROS = P000E4_A17TASA_BOMBEROS[0];
                     n17TASA_BOMBEROS = P000E4_n17TASA_BOMBEROS[0];
                     A16TREN_DE_ASEO = P000E4_A16TREN_DE_ASEO[0];
                     n16TREN_DE_ASEO = P000E4_n16TREN_DE_ASEO[0];
                     A18INTERES = P000E4_A18INTERES[0];
                     n18INTERES = P000E4_n18INTERES[0];
                     AV25Impuestos1 = A15IMPUESTO;
                     AV42TasaBomberos1 = A17TASA_BOMBEROS;
                     AV51TrenDeAseo1 = A16TREN_DE_ASEO;
                     AV30Interes3 = A18INTERES;
                     AV48Total1 = (decimal)(AV25Impuestos1+AV42TasaBomberos1+AV51TrenDeAseo1+AV30Interes3);
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
                  AV26Impuestostot = (decimal)(AV26Impuestostot+AV25Impuestos1);
                  AV52TrenDeAseotot = (decimal)(AV52TrenDeAseotot+AV51TrenDeAseo1);
                  AV43TasaBomberostot = (decimal)(AV43TasaBomberostot+AV42TasaBomberos1);
                  AV31Interestot = (decimal)(AV31Interestot+AV30Interes3);
                  AV49Totaltot = (decimal)(AV49Totaltot+AV48Total1);
                  H0E0( false, 32) ;
                  getPrinter().GxAttris("Arial", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11Anio), "ZZZ9")), 8, Gx_line+0, 91, Gx_line+31, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV25Impuestos1, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99 LPS")), 92, Gx_line+0, 217, Gx_line+31, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51TrenDeAseo1, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99 LPS")), 217, Gx_line+0, 367, Gx_line+31, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42TasaBomberos1, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99 LPS")), 367, Gx_line+0, 534, Gx_line+31, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48Total1, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99 LPS")), 667, Gx_line+0, 809, Gx_line+31, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV30Interes3, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99 LPS")), 533, Gx_line+0, 666, Gx_line+31, 1, 0, 0, 1) ;
                  getPrinter().GxDrawRect(8, Gx_line+0, 808, Gx_line+30, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(92, Gx_line+0, 92, Gx_line+31, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(217, Gx_line+0, 217, Gx_line+31, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(367, Gx_line+0, 367, Gx_line+31, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(533, Gx_line+0, 533, Gx_line+31, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(667, Gx_line+0, 667, Gx_line+31, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+32);
                  AV18Count5 = (short)(AV18Count5+1);
               }
               AV56Mensaje = "Recuerda que puedes aprovechar el descuento por pronto pago que vence el 30 de abril y la amnistía que esta vigente hasta el 30 de Junio.";
               AV57Mensaje2 = "Datos actualizados al 29 de febrero del 2024.";
               H0E0( false, 400) ;
               getPrinter().GxDrawRect(8, Gx_line+0, 808, Gx_line+31, 1, 0, 0, 0, 1, 192, 192, 192, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(667, Gx_line+0, 667, Gx_line+31, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(533, Gx_line+0, 533, Gx_line+31, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(367, Gx_line+0, 367, Gx_line+31, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(217, Gx_line+0, 217, Gx_line+31, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(92, Gx_line+0, 92, Gx_line+31, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Arial", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("TOTAL", 8, Gx_line+0, 91, Gx_line+31, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49Totaltot, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99 LPS")), 667, Gx_line+0, 809, Gx_line+31, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV31Interestot, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99 LPS")), 533, Gx_line+0, 666, Gx_line+31, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43TasaBomberostot, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99 LPS")), 367, Gx_line+0, 534, Gx_line+31, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52TrenDeAseotot, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99 LPS")), 217, Gx_line+0, 367, Gx_line+31, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV26Impuestostot, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99 LPS")), 92, Gx_line+0, 217, Gx_line+31, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Total a Pagar:", 8, Gx_line+67, 116, Gx_line+89, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49Totaltot, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99 LPS")), 117, Gx_line+67, 259, Gx_line+89, 1, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 14, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Mensaje, "")), 0, Gx_line+117, 817, Gx_line+184, 1+16, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Mensaje2, "")), 0, Gx_line+200, 817, Gx_line+267, 1+16, 0, 0, 1) ;
               getPrinter().GxDrawBitMap(context.GetImagePath( "09a25aae-18e3-4d8f-b315-08f46844995f", "", context.GetTheme( )), 242, Gx_line+267, 559, Gx_line+400) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+400);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0E0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H0E0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Arial", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Arial", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV61Ruta = "";
         AV23Fecha3 = DateTime.MinValue;
         AV55Hora = (DateTime)(DateTime.MinValue);
         P000E2_A6CLAVES_RUTASRUTA = new decimal[1] ;
         P000E2_n6CLAVES_RUTASRUTA = new bool[] {false} ;
         P000E2_A7UMAPS = new decimal[1] ;
         P000E2_n7UMAPS = new bool[] {false} ;
         P000E2_A1CLAVE_CATASTRAL = new string[] {""} ;
         A1CLAVE_CATASTRAL = "";
         AV53ART_ID_DOC = "";
         P000E3_A2ART_ID_DOC = new string[] {""} ;
         P000E3_A10NOMBRE = new string[] {""} ;
         P000E3_A9ACT_ID_CARD = new string[] {""} ;
         P000E3_A12NOMBRE_COLONIA = new string[] {""} ;
         P000E3_n12NOMBRE_COLONIA = new bool[] {false} ;
         A2ART_ID_DOC = "";
         A10NOMBRE = "";
         A9ACT_ID_CARD = "";
         A12NOMBRE_COLONIA = "";
         AV35Nombre = "";
         AV10ACT_ID_CARD = "";
         AV63NOMBRE_COLONIA = "";
         AV21Fecha = DateTime.MinValue;
         P000E4_A13OBL_YEAR = new short[1] ;
         P000E4_n13OBL_YEAR = new bool[] {false} ;
         P000E4_A2ART_ID_DOC = new string[] {""} ;
         P000E4_A15IMPUESTO = new decimal[1] ;
         P000E4_n15IMPUESTO = new bool[] {false} ;
         P000E4_A17TASA_BOMBEROS = new decimal[1] ;
         P000E4_n17TASA_BOMBEROS = new bool[] {false} ;
         P000E4_A16TREN_DE_ASEO = new decimal[1] ;
         P000E4_n16TREN_DE_ASEO = new bool[] {false} ;
         P000E4_A18INTERES = new decimal[1] ;
         P000E4_n18INTERES = new bool[] {false} ;
         AV56Mensaje = "";
         AV57Mensaje2 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aestadodecuenta__default(),
            new Object[][] {
                new Object[] {
               P000E2_A6CLAVES_RUTASRUTA, P000E2_n6CLAVES_RUTASRUTA, P000E2_A7UMAPS, P000E2_n7UMAPS, P000E2_A1CLAVE_CATASTRAL
               }
               , new Object[] {
               P000E3_A2ART_ID_DOC, P000E3_A10NOMBRE, P000E3_A9ACT_ID_CARD, P000E3_A12NOMBRE_COLONIA, P000E3_n12NOMBRE_COLONIA
               }
               , new Object[] {
               P000E4_A13OBL_YEAR, P000E4_n13OBL_YEAR, P000E4_A2ART_ID_DOC, P000E4_A15IMPUESTO, P000E4_n15IMPUESTO, P000E4_A17TASA_BOMBEROS, P000E4_n17TASA_BOMBEROS, P000E4_A16TREN_DE_ASEO, P000E4_n16TREN_DE_ASEO, P000E4_A18INTERES,
               P000E4_n18INTERES
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV15count ;
      private short AV62Anio23 ;
      private short AV18Count5 ;
      private short AV12Anio2 ;
      private short AV11Anio ;
      private short A13OBL_YEAR ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV13Clave ;
      private long AV64UMAPS ;
      private decimal A6CLAVES_RUTASRUTA ;
      private decimal A7UMAPS ;
      private decimal AV26Impuestostot ;
      private decimal AV52TrenDeAseotot ;
      private decimal AV43TasaBomberostot ;
      private decimal AV31Interestot ;
      private decimal AV49Totaltot ;
      private decimal AV30Interes3 ;
      private decimal AV25Impuestos1 ;
      private decimal AV42TasaBomberos1 ;
      private decimal AV51TrenDeAseo1 ;
      private decimal AV48Total1 ;
      private decimal A15IMPUESTO ;
      private decimal A17TASA_BOMBEROS ;
      private decimal A16TREN_DE_ASEO ;
      private decimal A18INTERES ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private DateTime AV55Hora ;
      private DateTime AV23Fecha3 ;
      private DateTime AV21Fecha ;
      private bool entryPointCalled ;
      private bool n6CLAVES_RUTASRUTA ;
      private bool n7UMAPS ;
      private bool n12NOMBRE_COLONIA ;
      private bool n13OBL_YEAR ;
      private bool n15IMPUESTO ;
      private bool n17TASA_BOMBEROS ;
      private bool n16TREN_DE_ASEO ;
      private bool n18INTERES ;
      private string AV61Ruta ;
      private string A1CLAVE_CATASTRAL ;
      private string AV53ART_ID_DOC ;
      private string A2ART_ID_DOC ;
      private string A10NOMBRE ;
      private string A9ACT_ID_CARD ;
      private string A12NOMBRE_COLONIA ;
      private string AV35Nombre ;
      private string AV10ACT_ID_CARD ;
      private string AV63NOMBRE_COLONIA ;
      private string AV56Mensaje ;
      private string AV57Mensaje2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] P000E2_A6CLAVES_RUTASRUTA ;
      private bool[] P000E2_n6CLAVES_RUTASRUTA ;
      private decimal[] P000E2_A7UMAPS ;
      private bool[] P000E2_n7UMAPS ;
      private string[] P000E2_A1CLAVE_CATASTRAL ;
      private string[] P000E3_A2ART_ID_DOC ;
      private string[] P000E3_A10NOMBRE ;
      private string[] P000E3_A9ACT_ID_CARD ;
      private string[] P000E3_A12NOMBRE_COLONIA ;
      private bool[] P000E3_n12NOMBRE_COLONIA ;
      private short[] P000E4_A13OBL_YEAR ;
      private bool[] P000E4_n13OBL_YEAR ;
      private string[] P000E4_A2ART_ID_DOC ;
      private decimal[] P000E4_A15IMPUESTO ;
      private bool[] P000E4_n15IMPUESTO ;
      private decimal[] P000E4_A17TASA_BOMBEROS ;
      private bool[] P000E4_n17TASA_BOMBEROS ;
      private decimal[] P000E4_A16TREN_DE_ASEO ;
      private bool[] P000E4_n16TREN_DE_ASEO ;
      private decimal[] P000E4_A18INTERES ;
      private bool[] P000E4_n18INTERES ;
   }

   public class aestadodecuenta__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000E2;
          prmP000E2 = new Object[] {
          new ParDef("@AV13Clave",GXType.Decimal,18,0)
          };
          Object[] prmP000E3;
          prmP000E3 = new Object[] {
          new ParDef("@AV53ART_ID_DOC",GXType.NVarChar,40,0)
          };
          Object[] prmP000E4;
          prmP000E4 = new Object[] {
          new ParDef("@AV53ART_ID_DOC",GXType.NVarChar,40,0) ,
          new ParDef("@AV11Anio",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000E2", "SELECT [RUTA], [UMAPS], [CLAVE_CATASTRAL] FROM dbo.[CLAVES_RUTAS] WHERE [RUTA] = @AV13Clave ORDER BY [CLAVE_CATASTRAL] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000E2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000E3", "SELECT [ART_ID_DOC], [NOMBRE], [ACT_ID_CARD], [NOMBRE_COLONIA] FROM dbo.[MORA] WHERE [ART_ID_DOC] = @AV53ART_ID_DOC ORDER BY [ART_ID_DOC] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000E3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P000E4", "SELECT [OBL_YEAR], [ART_ID_DOC], [IMPUESTO], [TASA_BOMBEROS], [TREN_DE_ASEO], [INTERES] FROM dbo.[MORA] WHERE ([ART_ID_DOC] = @AV53ART_ID_DOC) AND ([OBL_YEAR] = @AV11Anio) ORDER BY [ART_ID_DOC] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000E4,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}

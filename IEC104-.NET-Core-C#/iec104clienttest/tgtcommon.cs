/*****************************************************************************/
/*! \file        tgtcommon.cs
 *  \brief       Target Common structures & enums
 *	\author 	 FreyrSCADA Embedded Solution Pvt Ltd
 *	\copyright (c) FreyrSCADA Embedded Solution Pvt Ltd. All rights reserved.
 *
 * THIS IS PROPRIETARY SOFTWARE AND YOU NEED A LICENSE TO USE OR REDISTRIBUTE.
 *
 * THIS SOFTWARE IS PROVIDED BY FREYRSCADA AND CONTRIBUTORS ``AS IS'' AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
 * PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL FREYRSCADA OR CONTRIBUTORS BE
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR
 * BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR
 * OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/






public partial class tgtcommon
{
	
/******************************************************************************
*   Defines
******************************************************************************/

/*! \brief  Max Size of Object Name */
   public const int APP_OBJNAMESIZE  =       48;
    
/******************************************************************************
*   Enumeration
******************************************************************************/

 
	     /*! \brief Application Object State  */
    public enum  eAppState
     {
         APP_STATE_UNKNOWN           = 0,            /*!< A Unknown Object */
         APP_STATE_NEW               = 1,            /*!< A Newly create Object */
         APP_STATE_LOADED            = 2,            /*!< Object is loaded with a config and ready to run */
         APP_STATE_RUNNING           = 3,            /*!< Object is running  */
         APP_STATE_STOPPED           = 4,            /*!< Object Stopped */
         APP_STATE_FREED             = 5,            /*!< Object freed  */
     }

	     /*! \brief  Time Quality flag */
    public enum eTimeQualityFlags
    {
        TIME_ASSUMED                        = 0,   /*!< TIME   Assumed, not reported*/
        TIME_REPORTED                       = 1,   /*!< TIME   reported. */

    }

     /*! Application Flag */
    public enum eApplicationFlag
     {
        APP_SERVER          =   1,          /*!< Server Application */
        APP_CLIENT          =   2,          /*!< Client Application */
        APP_SERVERCLIENT    =   3,          /*!< ServerClient Application */
     }

    /*! Data types */
    public enum eDataTypes 
    {
        UNSUPPORTED_DATA        = 0,        /*!< Unsupported                        (0 Bit)     */              
        SINGLE_POINT_DATA       = 1,        /*!< Single Point Data Type             (1 Bit)     */
        DOUBLE_POINT_DATA       = 2,        /*!< Double Point  Data Type            (2 Bits)    */  
        UNSIGNED_BYTE_DATA      = 3,        /*!< Unsigned Byte Data Type            (8 Bits)    */  
        SIGNED_BYTE_DATA        = 4,        /*!< Signed Byte Data Type              (8 Bits)    */          
        UNSIGNED_WORD_DATA      = 5,        /*!< Unsigned Word Data Type            (16 Bits)   */  
        SIGNED_WORD_DATA        = 6,        /*!< Signed Word Data Type              (16 Bits)   */          
        UNSIGNED_DWORD_DATA     = 7,        /*!< Unsigned Double Word Data Type     (32 Bits)   */          
        SIGNED_DWORD_DATA       = 8,        /*!< Signed Double Word Data Type       (32 Bits)   */ 
        UNSIGNED_LWORD_DATA     = 9,        /*!< Unsigned Long word Data Type       (64 Bits)   */
        SIGNED_LWORD_DATA       = 10,       /*!< Singed long word Data Type         (64 Bits)   */
        UNSIGNED_LLWORD_DATA    = 11,       /*!< Unsigned Long Long Word Data Type  (128 Bits)  */
        SIGNED_LLWORD_DATA      = 12,       /*!< Signed Long Long Word Data Type    (128 Bits)  */
        FLOAT32_DATA            = 13,       /*!< Float 32 Data Type                 (32 Bits)    */
        FLOAT64_DATA            = 14,       /*!< Float 64 Data Type                 (64 Bits)   */
        FLOAT128_DATA           = 15,       /*!< Float 128 Data Type                (128 Bits)  */
        VISIBLE_STRING_DATA     = 16,       /*!< Visible String Data Type           (2040 Bits)  */
        MAX_DATATYPES,
    }

    /*!   Debug options flag */
    public enum eDebugOptionsFlag
    {
        DEBUG_OPTION_NONE                               = 0x0000,       /*!< No options set */
        DEBUG_OPTION_ERROR                              = 0x0001,       /*!< Error Messages only */
        DEBUG_OPTION_WARNING                            = 0x0002,       /*!< Warning Message only */     
        DEBUG_OPTION_RX                                 = 0x0004,       /*!< Rx Messages */
        DEBUG_OPTION_TX                                 = 0x0008,       /*!< Tx Messages */
    }

/******************************************************************************
*   Structures
******************************************************************************/

     /*! \brief SET Time Structure  */
      [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
    CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
     public struct sTargetTimeStamp
    {
        public byte u8Day;              /*!< Day 1 to 31 */
        public byte u8Month;            /*!< Month 1 to 12 */
        public ushort u16Year;            /*!< Year 1970 to 9999 */
        public byte u8DayoftheWeek;     /*!< 0 = Not Used Day of the week Mon = 1 to Sun = 7 */
        public byte u8Hour;             /*!< Hour 0 to 23 */
        public byte u8Minute;           /*!< Minutes 0 to 59 */
        public byte u8Seconds;          /*!< Seconds 0 to 59 */
        public ushort u16MilliSeconds;    /*!< Milliseconds 0 to 999 */
        public ushort u16MicroSeconds;    /*!< Micro Seconfs 0 to 999 */
        public sbyte i8DSTTime;          /*!< -1 DST Unknown, 0 (No DST), 1 to 24 (DST hour) */
    }


}
    


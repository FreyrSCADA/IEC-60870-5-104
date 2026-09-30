/*****************************************************************************/
/*! \file        tgtserialtypes.h
 *  \brief       Target Serial Types Header
 *  \author      FreyrSCADA Embedded Solution Pvt Ltd
 *  \copyright (c) FreyrSCADA Embedded Solution Pvt Ltd. All rights reserved.
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




/*!
 * \defgroup TgtSerialTypes Target Serial Types
 * \{
 */

#ifndef TGTSERIALTYPES_H
    #define TGTSERIALTYPES_H      1


/******************************************************************************
*   Enumerations
*******************************************************************************/

    /*! \brief Serial Flow Control */
    enum eSerialTypes
    {
        SERIAL_RS232         = 0,       /*!< Serial RS 232 */
        SERIAL_RS485         = 1,       /*!< Serial RS485*/
        SERIAL_RS422       = 2,       /*!< Serial RS422*/
    };

    /*! \brief Serial Data Length */
    enum eSerialWordLength
    {
        WORDLEN_7BITS           = 7,        /*!< Word Length 7 bits */
        WORDLEN_8BITS           = 8,        /*!< Word Lenght 8 bits */
    };

    /*! \brief Serial Stop Bits */
    enum eSerialStopBits
    {
        STOPBIT_1BIT            = 1,        /*!< Stop bit is 1 */
        STOPBIT_2BIT            = 2,        /*!< Stop bits is 2 */
    };

    /*! \brief Serial Parities */
    enum eSerialParity
    {
        NONE                    = 0,        /*!< No Parity */
        ODD                     = 1,        /*!< Odd Parity */
        EVEN                    = 2,        /*!< Even Parity */
    };

    /*! \brief Serial Flow Control */
    enum eLinuxSerialFlowControl
    {
        FLOW_NONE            = 0,       /*!< Disable Flow control */
        FLOW_RTS_CTS         = 1,       /*!< Enable Hardware RTS_CTS Flow control */
        FLOW_XON_XOFF        = 2,       /*!< Enable Software XON_XOFF Flow control */
    };

    /*! \brief Serial Baud Rates */
    enum eSerialBitRate
    {
        BITRATE_110         = 1,      /*!< Data rate of 110 Bit per second */
        BITRATE_300         = 3,      /*!< Data rate of 300 Bit per second */
        BITRATE_1200        = 12,     /*!< Data rate of 1200 Bit per second */
        BITRATE_2400        = 24,     /*!< Data rate of 2400 Bit per second */
        BITRATE_4800        = 48,     /*!< Data rate of 4800 Bit per second */
        BITRATE_9600        = 96,     /*!< Data rate of 9600 Bit per second */
        BITRATE_14400       = 144,    /*!< Data rate of 14400 Bit per second */
        BITRATE_19200       = 192,    /*!< Data rate of 19200 Bit per second */
        BITRATE_28800       = 288,    /*!< Data rate of 28800 Bit per second */
        BITRATE_38400       = 384,    /*!< Data rate of 38400 Bit per second */
        BITRATE_57600       = 576,    /*!< Data rate of 57600 Bit per second */
        BITRATE_115200      = 1152,   /*!< Data rate of 115200 Bit per second */
        BITRATE_230400      = 2304,   /*!< Data rate of 230400 Bit per second */
    };

     /*! \brief Windows RTS control*/
    enum eWinRTScontrol
    {
        WIN_RTS_CONTROL_DISABLE     = 0,    /*!< Lowers the RTS line when the device is opened. The application can use EscapeCommFunction to change the state of the line */
        WIN_RTS_CONTROL_ENABLE      = 1,    /*!< Raises the RTS line when the device is opened. The application can use EscapeCommFunction to change the state of the line */
        WIN_RTS_CONTROL_HANDSHAKE   = 2,    /*!< Enables RTS flow-control handshaking. The driver raises the RTS line, enabling the DCE to send, when the input buffer has enough room to receive data. The driver lowers the RTS line, preventing the DCE to send, when the input buffer does not have enough room to receive data. If this value is used, it is an error for the application to adjust the line with EscapeCommFunction */
        WIN_RTS_CONTROL_TOGGLE      = 3,    /*!< Specifies that the RTS line will be high if bytes are available for transmission. After all buffered bytes have been sent, the RTS line will be low. If this value is set, it would be an error for an application to adjust the line with EscapeCommFunction. This value is ignored in Windows 95; it causes the driver to act as if RTS_CONTROL_ENABLE were specified */
    };

     /*! \brief Windows DTR control */
    enum eWinDTRcontrol
    {
        WIN_DTR_CONTROL_DISABLE     =   0,  /*!< Lowers the DTR line when the device is opened. The application can adjust the state of the line with EscapeCommFunction */
        WIN_DTR_CONTROL_ENABLE      =   1,  /*!< Raises the DTR line when the device is opened. The application can adjust the state of the line with EscapeCommFunction */
        WIN_DTR_CONTROL_HANDSHAKE   =   2,  /*!< Enables DTR flow-control handshaking. If this value is used, it is an error for the application to adjust the line with EscapeCommFunction */
    };

/******************************************************************************
*   Structures
*******************************************************************************/
    /*! \brief Serial Flow control Parameters */
	struct sSerialFlowControl
    {
        enum eWinRTScontrol                     eWinRTS;                        /*!<    Windows Property - RTS control property defines setting for RTS pin of RS-232-C  */
        Boolean                                 bWinCTSoutputflow;              /*!<    Windows Property - CTS output flow property defines setting for CTS pin of RS-232-C */
        enum eWinDTRcontrol                     eWinDTR;                        /*!<    Windows Property - DTR control property defines setting for DTR pin of RS-232-C */
        Boolean                                 bWinDSRoutputflow;              /*!<    Windows Property - DSR output flow property defines setting for DSR pin of RS-232-C */
        enum eLinuxSerialFlowControl            eLinuxFlowControl;              /*!<    Flow Control for linux - more detail https://www.cmrr.umn.edu/~strupp/serial.html */
    };

    /*! \brief Serial Time Parameters */
    struct sSerialTimeParameters
    {
        Unsigned16                      u16PreDelay;            /*!< Delay before send or receive */
        Unsigned16                      u16PostDelay;           /*!< Delay after send or receive */
        Unsigned16                      u16InterCharacterDelay; /*!< Delay between characters during send or receive */
        Unsigned16                      u16CharacterTimeout;    /*!< Timeout if the character is not being sent or received */
        Unsigned8                       u8CharacterRetries;     /*!< Number of retries to send or receive a character */
        Unsigned16                      u16MessageTimeout;      /*!< Message Timeout if entire message is not sent or received */
        Unsigned8                       u8MessageRetries;       /*!< Message Retries to retry the entire message */
        Unsigned32                      u32Baud;                /*!< Bits per second used to calculate post transmit delay for RS485 */
    };

	        /*!  \struct     sSerialCommunicationSettings
        \brief      Communication Port Settings Structure.
        */
        struct sSerialCommunicationSettings
        {
            enum eSerialTypes               eSerialType;            /*!< Serial Type*/
            enum eSerialWordLength          eWordLength;         	/*!< Serial Word Length */
            enum eSerialStopBits            eStopBits;           	/*!< Serial Stop Bits*/
            enum eSerialParity              eSerialParity;       	/*!< Serial Parity */
            enum eSerialBitRate             eSerialBitRate;      	/*!< Serial Bit Rate */
            Unsigned16                      u16SerialPortNumber;    /*!< Serial COM port number*/
            Unsigned16                      u16InterMessageDelay;   /*!< Time between sending and receiving of message only applies after transmitting the message */
            struct sSerialFlowControl       sFlowControl;           /*!< Flow Control */
            struct sSerialTimeParameters    sTxTimeParam;           /*!< Transmission Time parameters */
            struct sSerialTimeParameters    sRxTimeParam;           /*!< Reception Time parameters */
        };


#endif

/*!
 *\}
 */

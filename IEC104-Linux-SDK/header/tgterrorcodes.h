/*****************************************************************************/
/*! \file        tgterrorcodes.h
 *  \brief       Target Common Error Codes
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





/*!
 * \defgroup ErrorCodes Error Codes
 * \{
 */

#ifndef TGTERRORCODES_H
    #define TGTERRORCODES_H      1

/******************************************************************************
*   Defines
******************************************************************************/
    /*! \brief  Target Error Codes */
    typedef Integer16  tErrorCode;

/******************************************************************************
*   Enumerations
******************************************************************************/

    /*! List of commom target error codes */
    enum eTgtErrorCodes
    {
        EC_NONE                                  =  0,       /*!< No Error Code */
        /* Common Error Codes */
        EC_PARAMETER                             = -1,       /*!< Invalid Parameter */
        EC_ERROR_VALUE_NULL                      = -2,       /*!< Pointer to Error Value is Null */
        /* Memory Related Error Codes */
        EC_MEMORY                                = -100,     /*!< Memory Error */
        /* Task Related Error Codes */
        EC_TASK_CREATE                           = -150,     /*!< Tasks Create Error */
        EC_TASK_DELETE                           = -151,     /*!< Tasks Delete Error */
        EC_TASK_ASSIGN_MEM                       = -152,     /*!< Error in Task Assign Memory */
        /* Semaphore Related Error Codes */
        EC_SEM_CREATE                            = -200,     /*!< Semaphore Create Error */
        EC_SEM_GET                               = -201,     /*!< Semaphore Get Error */
        EC_SEM_RELEASE                           = -202,     /*!< Semaphore Release Error */
        EC_SEM_DESTROY                           = -203,     /*!< Semaphore Destroy Error */
        EC_SEM_FIND                              = -204,     /*!< Unable To Find Semaphore */
        /* Timer Related Error Codes */
        EC_TIMER_CREATE                          = -250,     /*!< Timer Start Error */
        EC_TIMER_START                           = -251,     /*!< Timer Start Error */
        EC_TIMER_STOP                            = -252,     /*!< Timer Stop Error */
        EC_TIMER_RESET                           = -253,     /*!< Timer Reset Error */
        EC_TIMER_DESTROY                         = -254,     /*!< Timer Start Error */
        /* Socket Related Error Codes */
        EC_SOCKET_INITIAL                        = -300,     /*!< Socket Initialization Error*/
        EC_SOCKET_CREATE                         = -301,     /*!< Socket Start Error */
        EC_SOCKET_CLOSE                          = -302,     /*!< Socket Close Error */
        EC_SOCKET_SHUTDOWN                       = -303,     /*!< Socket Shut Down Error */
        EC_SOCKET_NONBLOCKING                    = -304,     /*!< Socket is non blocking */
        EC_SOCKET_BIND                           = -305,     /*!< Socket Bind Error */
        EC_SOCKET_LISTEN                         = -306,     /*!< Socket Listen Error */
        EC_SOCKET_ACCEPT                         = -307,     /*!< Socket Accept Error */
        EC_SOCKET_CONNECT                        = -308,     /*!< Socket Connect Error */
        EC_SOCKET_SEND                           = -309,     /*!< Socket Send Error */
        EC_SOCKET_RECEIVE                        = -310,     /*!< Socket Receive Error */
        EC_SOCKET_SEND_TO                        = -311,     /*!< Socket SendTo Errro */
        EC_SOCKET_RECEIVE_FROM                   = -312,     /*!< Socket Receive From Error */
        EC_SOCKET_SELECT                         = -313,     /*!< Socket Wait for Activity Error */
        EC_SOCKET_READ_READY                     = -314,     /*!< Socket is not ready to read */
        EC_SOCKET_CONNECT_NOT_SUCEED             = -315,     /*!< Socket Connect is not successful*/
        EC_SOCKET_KEEP_ALIVE                     = -316,     /*!< Socket Keep alive failed*/
        /* Time Managemet Related Error Codes */
        EC_SLEEP                                 = -350,     /*!< Sleep Failed*/
        EC_SET_TIME                              = -351,     /*!< Error Set System Time*/
        EC_GET_TIME                              = -352,     /*!< Error Get System Time*/
        /* File Related Error Codes */
        EC_FILE_OPEN                             = -400,     /*!< File Open Error */
        EC_FILE_CLOSE                            = -401,     /*!< File Close Error */
        EC_FILE_READ                             = -402,     /*!< File Read Error */
        EC_FILE_WRITE                            = -403,     /*!< File Write Error */
        EC_FILE_END                              = -404,     /*!< File End Error */
        EC_FILE_RENAME                           = -405,     /*!< File Rename */
        EC_CREATE_DIRECTORY                      = -406,     /*!< Create Directory*/
        EC_REMOVE_DIRECTORY                      = -407,     /*!< Remove Directory*/
        EC_CHANGE_DIRECTORY                      = -408,     /*!< Change Directory*/
        EC_GET_CURRENT_DIRECTORY                 = -409,     /*!< Get Current Working Directory*/
        EC_FILE_DELETE                           = -410,     /*!< Delete File */
        EC_FILE_FIND                             = -411,     /*!< Find File */
        EC_FILE_SIZE                             = -412,     /*!< File Size*/
        EC_FILE_SEEK                             = -413,     /*!< File Seek*/
        EC_LIST_DIRECTORY                        = -414,     /*!< List Directory*/
        /* LinkList Related Error Codes */
        EC_LIST_ADD                              = -450,     /*!< Link List Add Failed*/
        EC_LIST_INSERT                           = -451,     /*!< Link List Insert Failed*/
        /* Serial Communication */
        EC_SERIAL_OPEN                           = -500,     /*!< Error in Serial Open*/
        EC_SERIAL_CLOSE                          = -501,     /*!< Error in Serial Close*/
        EC_SERIAL_TRANSMIT                       = -502,     /*!< Error in Serial Transmit*/
        EC_SERIAL_RECEIVE                        = -503,     /*!< Error in Serial Receive*/
        /* Message Exchange Related Error Codes */
        EC_MESSAGE_CREATE                        = -550,     /*!< Error in Message Create*/
        EC_MESSAGE_DESTROY                       = -551,     /*!< Error in Message Destroy*/
        EC_MESSAGE_SEND                          = -552,     /*!< Error in Message Send*/
        EC_MESSAGE_RECEIVE                       = -553,     /*!< Error in Message Receive*/
        EC_MESSAGE_FIND                          = -554,     /*!< Error in Message Find*/
        /* Utility Related Error Codes */
        EC_UTILITY_FILEPOSTION                   = -600,     /*!< File Position Error */
        EC_UTILITY_GETSTRING                     = -601,     /*!< File Get String Error */
        EC_UTILITY_SECTIONNAME                   = -602,     /*!< File Section Name Error */
        EC_UTILITY_ITEMNAME                      = -603,     /*!< File Item and Text Error */
        EC_UTILITY_CREATECOMMONMEMORY            = -604,     /*!< Create common memory failed */
        EC_UTILITY_INITCOMMONMEMORY              = -605,     /*!< Initialize common memory failed */
        EC_UTILITY_DESTROYCOMMONMEMORY           = -606,     /*!< Destroy common memory failed */
        EC_UTILITY_GET_MAC_ADDRESS               = -607,     /*!< Get MAC Address FAILED*/
        EC_UTILITY_SYSTEM_REBOOT                 = -608,     /*!< System Reboot Failed*/
		EC_UTILITY_GET_HDD_SERIAL                = -609,     /*!< Get HDD Serial Failed*/
        /* GPIO Related Error Codes */
        EC_GPIO_OPEN                             = -650,     /*!< Error in GPIO Open*/
        EC_GPIO_READ                             = -651,     /*!< Error in GPIO Read*/
        EC_GPIO_WRITE                            = -652,     /*!< Error in GPIO Write*/
        /* Modbus Related Error Codes */
        EC_MODBUS_START                          =  -1000,    /*!< Modbus Error Codes Start */
        EC_MODBUS_END                            =  -1499,    /*!< Modbus Error Codes End */
        /* DNP3 Related Error Codes */
        EC_DNP3_START                            =  -1500,    /*!< DNP3 Error Codes Start */
        EC_DNP3_END                              =  -1999,    /*!< DNP3 Error Codes End */
        /* IEC103 Related Error Codes */
        EC_IEC103_START                          =  -2000,    /*!< IEC103 Error Codes Start */
        EC_IEC103_END                            =  -2499,    /*!< IEC103 Error Codes End */
        /* IEC104 Related Error Codes */
        EC_IEC104_START                          =  -2500,    /*!< IEC104 Error Codes Start */
        EC_IEC104_END                            =  -2999,    /*!< IEC104 Error Codes End */
        /* IEC101 Related Error Codes */
        EC_IEC101_START                          =  -4500,    /*!< IEC104 Error Codes Start */
        EC_IEC101_END                            =  -4999,    /*!< IEC104 Error Codes End */
        /* SPABUS Related Error Codes */
        EC_SPABUS_START                          =  -5000,    /*!< SPABUS Error Codes Start */
        EC_SPABUS_END                            =  -5499,    /*!< SPABUS Error Codes End */
		/* OPC Related Error Codes */
        EC_OPC_START							=  -6000,    /*!< OPC Error Codes Start */
        EC_OPC_END								=  -6499,    /*!< OPC Error Codes End */
    };

#endif

/*!
 *\}
 */

/*****************************************************************************/
/*! \file        tgterrorvalues.cs
 *  \brief       Target Common Error Values
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


/*! \file       
    \brief      
	\par		FreyrSCADA Embedded Solution Pvt Ltd
*/
    
    
public partial class tgterrorvalues
{

/******************************************************************************
*   Defines
******************************************************************************/            
   
   /*! \brief  Target Error Values */
   // typedef Integer16  tErrorValue;      

/******************************************************************************
*   Enumerations
******************************************************************************/    
    
    /*! List of Common Error value returned by API functions */
    enum eTgtErrorValues
    {        
        EV_NONE                                 =  0,        /*!< Everything was ok */
        /* Common Error Values */                        
        EV_PARAM_NULL                           = -1,       /*!< Parameter is NULL */
        EV_INVALID_VALUE                        = -2,       /*!< Parameter is Invalid Value */        
        EV_OUT_OF_RANGE                         = -3,       /*!< Parameter is Out of Range */        
        EV_ERRROCODE_NULL                       = -4,       /*!< Error Code is NULL */
        EV_NOT_SUPPORTED                        = -5,       /*!< Function Not Supported */
        EV_MAX_LIMIT                            = -6,       /*!< Exceeds Maximum Limit */
        EV_ALREADY_EXISTED                      = -7,       /*!< Already Existed With Same Name */
        EV_NOT_EXISTED                          = -8,       /*!< Not Existed */
       /* Memory Related Error Values */                        
        EV_OUT_OF_MEMORY                        = -100,     /*!< Memory NOT Available */
        EV_OS_FREE_MEMORY                       = -101,     /*!< Os Free Memory */  
        EV_MEMORY_SIZE_INVALID                  = -102,     /*!< Size of the Memory is invalid */
        /* Socket Related Error Values */                        
        EV_SOCKET_SELECT_TIMEOUT                = -300,     /*!< Function Wait for Activity Time Out */
        EV_SOCKET_READ_NOT_READY                = -301,     /*!< Socket Read not Ready */
        EV_SOCKET_CONNECTION_CLOSED             = -302,     /*!< Socket Connection closed */
        EV_SOCKET_NOT_READY                     = -303,     /*!< Socket not ready */ 
        /* Linked List Related Error Values */                                
        EV_LIST_IS_EMPTY                        = -350,     /*!< Link List is Empty */
        EV_NOT_FOUND                            = -351,     /*!< Element NOT Found */ 
        /* File Related Error Values */                                
        EV_NOT_END_OF_FILE                      = -400,     /*!< Not Reached End Of File */
        /* Serial Related Error Values */   
        EV_SERIAL_INITIAL                       = -500,     /*!< Serial Initial */
        EV_MESSAGE_INCOMPLETE                   = -501,     /*!< Not Fully Transmitted or Received */
        /* Message Related Error Values */   
        EV_MESSAGE_NOT_AVAILABLE                 = -550,     /*!< Message Not AVAILABLE */
        EV_MAC_ADDRESS_NOT_AVAILABLE             = -600,     /*!< MAC Address Not AVAILABLE */
        /* Modbus Related Error Values */
        EV_MODBUS_START                         =  -1000,    /*!< Modbus Error Values Start */
        EV_MODBUS_END                           =  -1499,    /*!< Modbus Error Values End */
        /* DNP3 Related Error Values */
        EV_DNP3_START                           =  -1500,    /*!< DNP3 Error Values Start */
        EV_DNP3_END                             =  -1999,    /*!< DNP3 Error Values End */
        /* IEC103 Related Error Values */
        EV_IEC103_START                         =  -2000,    /*!< IEC103 Error Values Start */
        EV_IEC103_END                           =  -2499,    /*!< IEC103 Error Values End */
        /* IEC104 Related Error Values */
        EV_IEC104_START                         =  -2500,    /*!< IEC104 Error Values Start */
        EV_IEC104_END                           =  -2999,    /*!< IEC104 Error Values End */
        /* IEC101 Related Error Values */
        EV_IEC101_START                         =  -4500,    /*!< IEC104 Error Values Start */
        EV_IEC101_END                           =  -4999,    /*!< IEC104 Error Values End */
        /* SPABUS Related Error Values */
        EV_SPABUS_START                         =  -5000,    /*!< SPABUS Error Values Start */
        EV_SPABUS_END                           =  -5499,    /*!< SPABUS Error Values End */

    }

}

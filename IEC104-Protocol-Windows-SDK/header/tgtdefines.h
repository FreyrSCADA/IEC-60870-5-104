/*****************************************************************************/
/*! \file        tgtdefines.h
 *  \brief       Target Common Defines 
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
 * \defgroup TgtDefines Target Definitions
 * \{
 */

#ifndef TGTDEFINES_H  
    #define TGTDEFINES_H    1       
    
/******************************************************************************
*   Definitions
******************************************************************************/  
    
    #ifndef FALSE        
        /*! \brief  Definition for false */
        #define FALSE       0 
    #endif

    #ifndef TRUE        
        /*! \brief  Definition for true */
        #define TRUE        1 
    #endif

    #ifndef ZERO        
        /*! \brief  Definition for zero */
        #define ZERO        0 
    #endif

    /*! \brief  Max Size of IPV4  Address */
    #define MAX_IPV4_ADDRSIZE          16

    /*! \brief  Max Size of IPV6  Address */
    #define MAX_IPV6_ADDRSIZE          40

    /*! \brief  Max Size of License Path */
    #define MAX_LICENSE_PATH        242

    /*! \brief  Max Size of Error Message sent to callback  */
    #define MAX_ERROR_MESSAGE       255

    /*! \brief  Max Size of Warning Message sent to callback  */
    #define MAX_WARNING_MESSAGE     255

    /*! \brief  UNUSED  for disable Warnings  - unused variables */
    #define UNUSED(expr) (void)(expr); 
        
#endif

/*!
 *\}
 */

/*****************************************************************************/
/*! \file        tgttypes.h
 *  \brief       Target Related Types
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




/*! \brief  Define Target Types */
#ifndef TGTTYPES_H
    #define TGTTYPES_H      1
    /******************************************************************************
    *   Includes
    ******************************************************************************/

    /* All target Specific headers must be defined here */
    #include <stdio.h>
	#include <string.h>
    #include <limits.h>
    #include <float.h>
    #include <wchar.h>
	#include <stdlib.h>
    #include <stdint.h>
    #include <pthread.h>
    #include <semaphore.h>
    #include <time.h>
	#include <mqueue.h>
    #include "tgtdefines.h"

    /******************************************************************************
    *   Defines
    ******************************************************************************/

    //#define PACKED   __attribute__((packed))

    /*! \brief  Size : 8 bits       Range : TRUE or FASE */
    typedef uint8_t                 Boolean;
    /*! \brief  Size : 8 bits       Range : 0 to 255 */
    typedef uint8_t                 Unsigned8;
    /*! \brief  Size : 8 bits       Range : -128 to 127 */
    typedef int8_t                  Integer8;
    /*! \brief  Size : 16 bits      Range : 0 to 65,535  */
    typedef uint16_t                Unsigned16;
    /*! \brief  Size : 16 bits      Range : -32,768 to 32,767 */
    typedef int16_t                 Integer16;
    /*! \brief  Size : 32 bits      Range : 0 to 4,294,967,295 */
    typedef uint32_t                Unsigned32;
    /*! \brief  Size : 32 bits      Range : -2,147,483,648 to 2,147,483,647 */
    typedef int32_t                 Integer32;
    /*! \brief  Size : 64 bits      Range : 0 to 18,446,744,073,709,551,616 */
    typedef uint64_t                Unsigned64;
    /*! \brief  Size : 64 bits      Range : -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 */
    typedef int64_t                 Integer64;
    /*! \brief  Size : 128 bits     Range : 0 to 18,446,744,073,709,551,616  (NOTE : Linux 32 bit OS ONLY SUPPORTS 64 bits) */
    typedef uint64_t                Unsigned128;
    /*! \brief  Size : 128 bits     Range : -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 (NOTE : Linux 32 bit OS ONLY SUPPORTS 64 bits) */
    typedef int64_t                 Integer128;
    /*! \brief  Size : 32 bits      Range : 1.175494e-38 to 3.402823e+38 */
    typedef float                   Float32;
    /*! \brief  Size : 64 bits      Range : 2.225074e-308 to 1.797693e+308 */
    typedef double                  Float64;
    /*! \brief  Size : 128 bits     Range : 2.225074e-308 to 1.797693e+308 */
    typedef long double             Float128;
    /*! \brief  Size : 16 bits      Range : 0 to 65535 */
    typedef wchar_t                 Unicode;
    /*! \brief  Size : Depends on the Platform */
    typedef size_t                  UnSize;


    /*! \brief  Task Identification */
    typedef pthread_t               tTaskIdentification;
    /*! \brief  Semaphore Identification */
    typedef sem_t                   tSemaphoreIdentification;
    /*! \brief  Timer Identification */
    typedef timer_t                 tTimerIdentification;
    /*! \brief  Socket Descriptor */
    typedef Integer16               tSocketDescriptor;
    /*! \brief  Message Identification */
    typedef mqd_t                   tMessageIdentification;

    /*! \brief  Minimum Boolean Value  */
    #define MIN_BOOLEAN     FALSE
    /*! \brief  Maximum Boolean Value  */
    #define MAX_BOOLEAN     TRUE
    /*! \brief  Minimum Unsigned 8 bit Value  */
    #define MIN_UINT8       ZERO
    /*! \brief  Maximum Unsigned 8 bit Value  */
    #define MAX_UINT8       UCHAR_MAX
    /*! \brief  Minimum Signed 8 bit Value  */
    #define MIN_INT8        SCHAR_MIN
    /*! \brief  Maximum Signed 8 bit Value  */
    #define MAX_INT8        SCHAR_MAX
    /*! \brief  Minimum Unsigned 16 bit Value  */
    #define MIN_UINT16      ZERO
    /*! \brief  Maximum Unsigned 16 bit Value  */
    #define MAX_UINT16      USHRT_MAX
    /*! \brief  Minimum Signed 16 bit Value  */
    #define MIN_INT16       SHRT_MIN
    /*! \brief  Maximum Signed 16 bit Value  */
    #define MAX_INT16       SHRT_MAX
    /*! \brief  Minimum Unsigned 32 bit Value  */
    #define MIN_UINT32      ZERO
    /*! \brief  Maximum Unsigned 32 bit Value  */
    #define MAX_UINT32      ULONG_MAX
    /*! \brief  Minimum Signed 32 bit Value  */
    #define MIN_INT32       LONG_MIN
    /*! \brief  Maximum Signed 32 bit Value  */
    #define MAX_INT32       LONG_MAX
    /*! \brief  Minimum Unsigned 64 bit Value  */
    #define MIN_UINT64      ZERO
    /*! \brief  Maximum Unsigned 64 bit Value  */
    #define MAX_UINT64      ULLONG_MAX
    /*! \brief  Minimum Signed 64 bit Value  */
    #define MIN_INT64       LLONG_MIN
    /*! \brief  Maximum Signed 64 bit Value  */
    #define MAX_INT64       LLONG_MAX
    /*! \brief  Minimum Unsigned 128 bit Value  */
    #define MIN_UINT128      ZERO
    /*! \brief  Maximum Unsigned 128 bit Value  */
    #define MAX_UINT128      ULLONG_MAX
    /*! \brief  Minimum Signed 128 bit Value  */
    #define MIN_INT128       LLONG_MIN
    /*! \brief  Maximum Signed 128 bit Value  */
    #define MAX_INT128       LLONG_MAX
    /*! \brief  Minimum Float 32 bit Value  */
    #define MIN_FLOAT32     FLT_MIN
    /*! \brief  Maximum Float 32 bit Value  */
    #define MAX_FLOAT32     FLT_MAX
    /*! \brief  Minimum Float 64 bit Value  */
    #define MIN_FLOAT64     DBL_MIN
    /*! \brief  Maximum Float 64 bit Value  */
    #define MAX_FLOAT64     DBL_MAX
    /*! \brief  Minimum Float 128 bit Value  */
    #define MIN_FLOAT128    LDBL_MIN
    /*! \brief  Maximum Float 128 bit Value  */
    #define MAX_FLOAT128    LDBL_MAX
    /*! \brief  Minimum Float 128 bit Value  */
    #define MIN_FLOAT128    LDBL_MIN
    /*! \brief  Maximum Float 128 bit Value  */
    #define MAX_FLOAT128    LDBL_MAX
    /*! \brief  Minimum Unicode Value  */
    #define MIN_UNICODE     WCHAR_MIN
    /*! \brief  Maximum Unicode Value  */
    #define MAX_UNICODE     WCHAR_MAX
    /*! \brief  Minimum Unsigned Size */
    #define MIN_UNSIZE      ZERO
    /*! \brief  Maximum Unsigned Size */
    #define MAX_UNSIZE      MAX_SIZE

    /*! Data size */
    enum eDataSizes
    {
        UNSUPPORTED_SIZE        = 0,        /*!< Unsupported                        (0)         */
        SINGLE_POINT_SIZE       = 1,        /*!< Single Point Data Size             (1 Byte)    */
        DOUBLE_POINT_SIZE       = 1,        /*!< Double Point  Data Size            (1 Byte)    */
        UNSIGNED_BYTE_SIZE      = 1,        /*!< Unsigned Byte Data Size            (1 Byte)    */
        SIGNED_BYTE_SIZE        = 1,        /*!< Signed Byte Data Size              (1 Byte)    */
        UNSIGNED_WORD_SIZE      = 2,        /*!< Unsigned Word Data Size            (2 Bytes)   */
        SIGNED_WORD_SIZE        = 2,        /*!< Signed Word Data Size              (2 Bytes)   */
        UNSIGNED_DWORD_SIZE     = 4,        /*!< Unsigned Double Word Data Size     (4 Bytes)   */
        SIGNED_DWORD_SIZE       = 4,        /*!< Signed Double Word Data Size       (4 Bytes)   */
        UNSIGNED_LWORD_SIZE     = 8,        /*!< Unsigned Long word Data Size       (8 Bytes)   */
        SIGNED_LWORD_SIZE       = 8,        /*!< Singed long word Data Size         (8 Bytes)   */
        UNSIGNED_LLWORD_SIZE    = 8,        /*!< Unsigned Long Long Word Data Size  (16 Bytes)  */
        SIGNED_LLWORD_SIZE      = 8,        /*!< Signed Long Long Word Data Size    (16 Bytes)  */
        FLOAT32_SIZE            = 4,        /*!< Float 32 Data Size                 (4 Bytes)   */
        FLOAT64_SIZE            = 8,        /*!< Float 64 Data Size                 (8 Bytes)   */
        FLOAT128_SIZE           = 8,       /*!< Float 128 Data Size                (16 Bytes)   */
        STRING_SIZE             = 255,      /*!< String Data Size                   (255 Bytes)*/
        MAX_DATASIZE            = 255,      /*!< Maximum Data Size */
    };

    /*! \brief  API function prefix (for functions called from user application) */
    #define PUBLICAPIPX
    /*! \brief  Private function prefix (for functions called within a C file but not used for library) */
    #define PRIVATEPX       static
    /*! \brief  External function prefix (for functions called from outside c file but used within the library) */
    #define PUBLICPX
    /*! \brief  Task function prefix */
    #define TASKPX          static void
    /*! \brief  API function suffix (for functions called from user application) */
    #define PUBLICAPISX
    /*! \brief  Private function prefix (for functions called within a C file but not used for library) */
    #define PRIVATESX
    /*! \brief  External function prefix (for functions called from outside c file but used within the library) */
    #define PUBLICSX
    /*! \brief  task function suffix */
    #define TASKSX
#endif

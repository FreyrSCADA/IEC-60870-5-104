from enum import *

class eDataSizes(IntEnum):
    UNSUPPORTED_SIZE = 0        # Unsupported                        (0)
    SINGLE_POINT_SIZE = 1       # Single Point Data Size             (1 Byte)
    DOUBLE_POINT_SIZE = 1       # Double Point  Data Size            (1 Byte)
    UNSIGNED_BYTE_SIZE = 1      # Unsigned Byte Data Size            (1 Byte)
    SIGNED_BYTE_SIZE = 1        # Signed Byte Data Size              (1 Byte)
    UNSIGNED_WORD_SIZE = 2      # Unsigned Word Data Size            (2 Bytes)
    SIGNED_WORD_SIZE = 2        # Signed Word Data Size              (2 Bytes)
    UNSIGNED_DWORD_SIZE = 4     # Unsigned Double Word Data Size     (4 Bytes)
    SIGNED_DWORD_SIZE = 4       # Signed Double Word Data Size       (4 Bytes)
    UNSIGNED_LWORD_SIZE = 8     # Unsigned Long word Data Size       (8 Bytes)
    SIGNED_LWORD_SIZE = 8       # Signed long word Data Size         (8 Bytes)
    UNSIGNED_LLWORD_SIZE = 8    # Unsigned Long Long Word Data Size  (16 Bytes)
    SIGNED_LLWORD_SIZE = 8      # Signed Long Long Word Data Size    (16 Bytes)
    FLOAT32_SIZE = 4            # Float 32 Data Size                 (4 Bytes)
    FLOAT64_SIZE = 8            # Float 64 Data Size                 (8 Bytes)
    FLOAT128_SIZE = 8           # Float 128 Data Size                (16 Bytes)
    STRING_SIZE = 255           # String Data Size                   (255 Bytes)
    MAX_DATASIZE = 255          # Maximum Data Size


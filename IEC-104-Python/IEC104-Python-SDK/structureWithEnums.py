import ctypes
import enum

#
#   Prerequisits:
#   -------------
#   If you are using Python < 3.4 run `pip install enum34`.
#
#   Problem Definition
#   ------------------
#   ctypes.Structure class doesn't support enumerations out-of-the-box.
#   Consider the following (non-working) example:
#
#   class EnableDisableType(enum.IntEnum):
#       ENABLE = 1
#       DISABLE = 2

#   class SomeStructure(ctypes.Structure):
#       _fields_ = [
#           ("value", ctypes.c_uint32),
#           ("switch", EnableDisableType),
#       ]
#
#    Solution:
#    ---------
#    1). Use the following `StructureWithEnums` class instead of `ctypes.Structure`.
#    2). Add `_map`attribute to your structure definition (which maps field names to enumeration types).
#    3)  Replace enumeration types in your `_fields_` list with `ctypes.c_int`.
#    Voilà!
#
#    class SomeStructure(StructureWithEnums):
#        _fields_ = [
#            ("value", ctypes.c_uint32),
#            ("switch", ctypes.c_int),
#        ]
#        _map = {
#            "switch":  EnableDisableType
#        }
#

class StructureWithEnums(ctypes.Structure):
    """Add missing enum feature to ctypes Structures.
    """
    _map = {}

    def __getattribute__(self, name):
        _map = ctypes.Structure.__getattribute__(self, '_map')
        value = ctypes.Structure.__getattribute__(self, name)
        if name in _map:
            EnumClass = _map[name]
            if isinstance(value, ctypes.Array):
                return [EnumClass(x) for x in value]
            else:
                return EnumClass(value)
        else:
            return value

    def __str__(self):
        result = []
        result.append("struct {0} {{".format(self.__class__.__name__))
        for field in self._fields_:
            attr, attrType = field
            if attr in self._map:
                attrType = self._map[attr]
            value = getattr(self, attr)
            result.append("    {0} [{1}] = {2!r};".format(attr, attrType.__name__, value))
        result.append("};")
        return '\n'.join(result)

    __repr__ = __str__
##

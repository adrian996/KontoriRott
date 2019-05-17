// This file declares the IPropertyStoreCapabilities Interface and Gateway for Python.
// Generated by makegw.py
// ---------------------------------------------------
//
// Interface Declaration
#include "PythonCOM.h"
#include "PythonCOMServer.h"
#include "propsys.h"
#include "PyPROPVARIANT.h"
class PyIPropertyStoreCapabilities : public PyIUnknown
{
public:
	MAKE_PYCOM_CTOR(PyIPropertyStoreCapabilities);
	static IPropertyStoreCapabilities *GetI(PyObject *self);
	static PyComTypeObject type;

	// The Python methods
	static PyObject *IsPropertyWritable(PyObject *self, PyObject *args);

protected:
	PyIPropertyStoreCapabilities(IUnknown *pdisp);
	~PyIPropertyStoreCapabilities();
};
// ---------------------------------------------------
//
// Gateway Declaration

class PyGPropertyStoreCapabilities : public PyGatewayBase, public IPropertyStoreCapabilities
{
protected:
	PyGPropertyStoreCapabilities(PyObject *instance) : PyGatewayBase(instance) { ; }
	PYGATEWAY_MAKE_SUPPORT2(PyGPropertyStoreCapabilities, IPropertyStoreCapabilities, IID_IPropertyStoreCapabilities, PyGatewayBase);

	// IPropertyStoreCapabilities
	STDMETHOD(IsPropertyWritable)(REFPROPERTYKEY key);

};

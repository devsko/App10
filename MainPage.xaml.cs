using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            new Geopath(new List<BasicGeoposition>() { new(0, 0, 0) });

            IEnumerable<BasicGeoposition> Points()
            {
                yield return new(0, 0, 0);
            }
            new Geopath(Points());

            new Geopath([new(0, 0, 0)]);
            // System.InvalidCastException: Specified cast is not valid.
            //    at System.Runtime.InteropServices.Marshal.ThrowExceptionForHR(Int32 errorCode)
            //    at WinRT.ComWrappersSupport.CreateCCWForObjectForABI(Object obj, Guid iid)
            //    at WinRT.ComWrappersSupport.CreateCCWForObjectForMarshaling(Object obj, Guid iid)
            //    at WinRT.MarshalInspectable`1.CreateMarshaler2(T o, Guid iid, Boolean unwrapObject)
            //    at WinRT.MarshalInterface`1.CreateMarshaler2(T value, Guid iid)
            //    at Windows.Devices.Geolocation.Geopath._IGeopathFactoryMethods.Create(IObjectReference _obj, IEnumerable`1 positions)
            //    at Windows.Devices.Geolocation.Geopath..ctor(IEnumerable`1 positions)

            new Geopath(new BasicGeoposition[] { new(0, 0, 0) });
            // System.NotSupportedException: Cannot provide IReferenceArray`1 support for element type 'Windows.Devices.Geolocation.BasicGeoposition'.
            //    at WinRT.ComWrappersSupport.ProvideIReferenceArray(Type arrayType)
            //    at WinRT.ComWrappersSupport.GetInterfaceTableEntries(Type type)
            //    at WinRT.DefaultComWrappers.<>c.<ComputeVtables>b__7_0(Type type)
            //    at System.Runtime.CompilerServices.ConditionalWeakTable`2.GetValueLocked(TKey key, CreateValueCallback createValueCallback)
            //    at System.Runtime.CompilerServices.ConditionalWeakTable`2.GetValue(TKey key, CreateValueCallback createValueCallback)
            //    at WinRT.DefaultComWrappers.ComputeVtables(Object obj, CreateComInterfaceFlags flags, Int32& count)
            //    at System.Runtime.InteropServices.ComWrappers.TryGetOrCreateComInterfaceForObjectInternal(ObjectHandleOnStack comWrappersImpl, Int64 wrapperId, ObjectHandleOnStack instance, CreateComInterfaceFlags flags, IntPtr& retValue)
            //    at System.Runtime.InteropServices.ComWrappers.TryGetOrCreateComInterfaceForObjectInternal(ComWrappers impl, Object instance, CreateComInterfaceFlags flags, IntPtr& retValue)
            //    at System.Runtime.InteropServices.ComWrappers.GetOrCreateComInterfaceForObject(Object instance, CreateComInterfaceFlags flags)
            //    at WinRT.ComWrappersSupport.CreateCCWForObjectForABI(Object obj, Guid iid)
            //    at WinRT.ComWrappersSupport.CreateCCWForObjectForMarshaling(Object obj, Guid iid)
            //    at WinRT.MarshalInspectable`1.CreateMarshaler2(T o, Guid iid, Boolean unwrapObject)
            //    at WinRT.MarshalInterface`1.CreateMarshaler2(T value, Guid iid)
            //    at Windows.Devices.Geolocation.Geopath._IGeopathFactoryMethods.Create(IObjectReference _obj, IEnumerable`1 positions)
            //    at Windows.Devices.Geolocation.Geopath..ctor(IEnumerable`1 positions)

            MapStyleSheet.Combine([MapStyleSheet.Aerial()]);
            // System.InvalidCastException: Specified cast is not valid.
            //    at WinRT.ComWrappersSupport.CreateCCWForObjectForABI(Object obj, Guid iid)
            //    at WinRT.ComWrappersSupport.CreateCCWForObjectForMarshaling(Object obj, Guid iid)
            //    at WinRT.MarshalInspectable`1.CreateMarshaler2(T o, Guid iid, Boolean unwrapObject)
            //    at System.Runtime.InteropServices.Marshal.ThrowExceptionForHR(Int32 errorCode)
            //    at WinRT.MarshalInterface`1.CreateMarshaler2(T value, Guid iid)
            //    at ABI.Windows.UI.Xaml.Controls.Maps.IMapStyleSheetStaticsMethods.Combine(IObjectReference _obj, IEnumerable`1 styleSheets)
            //    at Windows.UI.Xaml.Controls.Maps.MapStyleSheet.Combine(IEnumerable`1 styleSheets)

            MapStyleSheet.Combine(new MapStyleSheet[] { MapStyleSheet.Aerial() }); 
            // works when AllowUnsafeBlocks=true, InvalidCastException otherwise
        }
    }
}

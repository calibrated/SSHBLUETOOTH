package crc645baa7f28875ae681;


public class AndroidBluetoothConnect
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onActivityResult:(IILandroid/content/Intent;)V:GetOnActivityResult_IILandroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("BluetoothTesting.Droid.AndroidBluetoothConnect, BluetoothTesting.Android", AndroidBluetoothConnect.class, __md_methods);
	}


	public AndroidBluetoothConnect ()
	{
		super ();
		if (getClass () == AndroidBluetoothConnect.class)
			mono.android.TypeManager.Activate ("BluetoothTesting.Droid.AndroidBluetoothConnect, BluetoothTesting.Android", "", this, new java.lang.Object[] {  });
	}


	public void onActivityResult (int p0, int p1, android.content.Intent p2)
	{
		n_onActivityResult (p0, p1, p2);
	}

	private native void n_onActivityResult (int p0, int p1, android.content.Intent p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

using UnityEngine;
using System.Collections.Generic;




#if UNITY_ANDROID

public enum MoPubAdPosition
{
	TopLeft,
	TopCenter,
	TopRight,
	Centered,
	BottomLeft,
	BottomCenter,
	BottomRight
}

public enum MoPubLocationAwareness
{
	TRUNCATED,
	DISABLED,
	NORMAL
}



public class MoPubAndroid
{
	private static AndroidJavaObject _plugin;


	static MoPubAndroid()
	{
		if( Application.platform != RuntimePlatform.Android )
			return;

		using( var pluginClass = new AndroidJavaClass( "com.mopub.unity.MoPubUnityPlugin" ) )
			_plugin = pluginClass.CallStatic<AndroidJavaObject>( "instance" );
	}



	public static void addFacebookTestDeviceId( string hashedDeviceId )
	{
		if( Application.platform != RuntimePlatform.Android )
			return;

		_plugin.Call( "addFacebookTestDeviceId", hashedDeviceId );
	}


	public static void addAdMobTestDeviceId( string deviceId )
	{
		if( Application.platform != RuntimePlatform.Android )
			return;

		_plugin.Call( "addAdMobTestDeviceId", deviceId );
	}


	// Enables/disables location support for banners and interstitials
	public static void setLocationAwareness( MoPubLocationAwareness locationAwareness )
	{
		if( Application.platform != RuntimePlatform.Android )
			return;

		_plugin.Call( "setLocationAwareness", locationAwareness.ToString() );
	}


	// Creates a banner of the given type at the given position
	public static void createBanner( string adUnitId, MoPubAdPosition position )
	{
		if( Application.platform != RuntimePlatform.Android )
			return;

		_plugin.Call( "createBanner", adUnitId, (int)position );
	}


	// Destroys the banner and removes it from view
	public static void destroyBanner()
	{
		if( Application.platform != RuntimePlatform.Android )
			return;

		_plugin.Call( "destroyBanner" );
	}


	// Shows/hides the banner
	public static void showBanner( bool shouldShow )
	{
		if( Application.platform != RuntimePlatform.Android )
			return;

		_plugin.Call( "hideBanner", !shouldShow );
	}


	// Sets the keywords for the current banner
	public static void setBannerKeywords( string keywords )
	{
		if( Application.platform != RuntimePlatform.Android )
			return;

		_plugin.Call( "setBannerKeywords", keywords );
	}


	// Starts loading an interstitial ad
	public static void requestInterstitialAd( string adUnitId, string keywords = "" )
	{
		if( Application.platform != RuntimePlatform.Android )
			return;

		_plugin.Call( "requestInterstitialAd", adUnitId, keywords );
	}


	// If an interstitial ad is loaded this will take over the screen and show the ad
	public static void showInterstitialAd( string adUnitId )
	{
		if( Application.platform != RuntimePlatform.Android )
			return;

		_plugin.Call( "showInterstitialAd" );
	}


	// Reports an app download to MoPub
	public static void reportApplicationOpen()
	{
		if( Application.platform != RuntimePlatform.Android )
			return;

		_plugin.Call( "reportApplicationOpen" );
	}


	// Initializes the rewarded video system
	public static void initializeRewardedVideo()
	{
		if( Application.platform != RuntimePlatform.Android )
			return;

		_plugin.Call( "initializeRewardedVideo" );
	}


	// Starts loading a rewarded video ad
	public static void requestRewardedVideo( string adUnitId, List<MoPubMediationSetting> mediationSettings = null,
		string keywords = null, double latitude = MoPub.LAT_LONG_SENTINEL, double longitude = MoPub.LAT_LONG_SENTINEL )
	{
		if( Application.platform != RuntimePlatform.Android )
			return;

		var json = mediationSettings == null ? null : MoPubMiniJSON.Json.Serialize( mediationSettings );
		_plugin.Call( "requestRewardedVideo", adUnitId, json, keywords, latitude, longitude );
	}


	// If a rewarded video ad is loaded this will take over the screen and show the ad
	public static void showRewardedVideo( string adUnitId )
	{
		if( Application.platform != RuntimePlatform.Android )
			return;

		_plugin.Call( "showRewardedVideo", adUnitId );
	}
}
#endif
using UnityEngine;
using System;
using System.Collections.Generic;


#if UNITY_IPHONE || UNITY_ANDROID

#if UNITY_IPHONE
using MP = MoPubBinding;
#elif UNITY_ANDROID
	using MP = MoPubAndroid;
#endif


public class MoPubMediationSetting : Dictionary<string,object>
{
	public MoPubMediationSetting( string adVendor )
	{
		this.Add( "adVendor", adVendor );
	}
}


public static class MoPub
{
	public const double LAT_LONG_SENTINEL = 99999.0;

	// Enables/disables location support for banners and interstitials
	public static void enableLocationSupport( bool shouldUseLocation )
	{
#if UNITY_IPHONE
		MoPubBinding.enableLocationSupport( true );
#elif UNITY_ANDROID
		MoPubAndroid.setLocationAwareness( MoPubLocationAwareness.NORMAL );
#endif
	}


	// Creates a banner of the given type at the given position. bannerType is iOS only.
#if UNITY_IPHONE
	public static void createBanner( string adUnitId, MoPubAdPosition position, MoPubBannerType bannerType = MoPubBannerType.Size320x50 )
	{
		MoPubBinding.createBanner( bannerType, position, adUnitId );
	}

#elif UNITY_ANDROID

	public static void createBanner( string adUnitId, MoPubAdPosition position )
	{
		MoPubAndroid.createBanner( adUnitId, position );
	}

#endif


	// Destroys the banner and removes it from view
	public static void destroyBanner()
	{
		MP.destroyBanner();
	}


	// Shows/hides the banner
	public static void showBanner( bool shouldShow )
	{
		MP.showBanner( shouldShow );
	}


	// Starts loading an interstitial ad
	public static void requestInterstitialAd( string adUnitId, string keywords = "" )
	{
		MP.requestInterstitialAd( adUnitId, keywords );
	}


	// If an interstitial ad is loaded this will take over the screen and show the ad
	public static void showInterstitialAd( string adUnitId )
	{
		MP.showInterstitialAd( adUnitId );
	}


	// Reports an app download to MoPub. iTunesAppId is iOS only.
	public static void reportApplicationOpen( string iTunesAppId = null )
	{
#if UNITY_IPHONE
		MoPubBinding.reportApplicationOpen( iTunesAppId );
#elif UNITY_ANDROID
		MoPubAndroid.reportApplicationOpen();
#endif
	}


	// Initializes the rewarded video system
	public static void initializeRewardedVideo()
	{
		MP.initializeRewardedVideo();
	}


	// Starts loading a rewarded video ad
	public static void requestRewardedVideo( string adUnitId, List<MoPubMediationSetting> mediationSettings = null,
		string keywords = null, double latitude = LAT_LONG_SENTINEL, double longitude = LAT_LONG_SENTINEL)
	{
		MP.requestRewardedVideo( adUnitId, mediationSettings, keywords, latitude, longitude );
	}


	// If a rewarded video ad is loaded this will take over the screen and show the ad
	public static void showRewardedVideo( string adUnitId )
	{
		MP.showRewardedVideo( adUnitId );
	}

}

#endif
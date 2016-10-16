using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


#if UNITY_IPHONE || UNITY_ANDROID
public class MoPubManager : MonoBehaviour
{
	// Fired when an ad loads in the banner. Includes the ad height.
	public static event Action<float> onAdLoadedEvent;

	// Fired when an ad fails to load for the banner
	public static event Action onAdFailedEvent;

	// Android only. Fired when a banner ad is clicked
	public static event Action onAdClickedEvent;

	// Android only. Fired when a banner ad expands to encompass a greater portion of the screen
	public static event Action onAdExpandedEvent;

	// Android only. Fired when a banner ad collapses back to its initial size
	public static event Action onAdCollapsedEvent;

	// Fired when an interstitial ad is loaded and ready to be shown
	public static event Action onInterstitialLoadedEvent;

	// Fired when an interstitial ad fails to load
	public static event Action onInterstitialFailedEvent;

	// Fired when an interstitial ad is dismissed
	public static event Action onInterstitialDismissedEvent;

	// iOS only. Fired when an interstitial ad expires
	public static event Action onInterstitialExpiredEvent;

	// Android only. Fired when an interstitial ad is displayed
	public static event Action onInterstitialShownEvent;

	// Android only. Fired when an interstitial ad is clicked
	public static event Action onInterstitialClickedEvent;

	// Fired when a rewarded video finishes loading and is ready to be displayed
	public static event Action<string> onRewardedVideoLoadedEvent;

	// Fired when a rewarded video fails to load. Includes the error message.
	public static event Action<string> onRewardedVideoFailedEvent;

	// iOS only. Fired when a rewarded video expires
	public static event Action<string> onRewardedVideoExpiredEvent;
	
	// Fired when an rewarded video is displayed
	public static event Action<string> onRewardedVideoShownEvent;

	// Fired when a rewarded video fails to play. Includes the error message.
	public static event Action<string> onRewardedVideoFailedToPlayEvent;

	// Fired when a rewarded video completes. Includes all the data available about the reward.
	public static event Action<RewardedVideoData> onRewardedVideoReceivedRewardEvent;

	// Fired when a rewarded video closes
	public static event Action<string> onRewardedVideoClosedEvent;

	// iOS only. Fired when a rewarded video event causes another application to open
	public static event Action<string> onRewardedVideoLeavingApplicationEvent;



	public class RewardedVideoData
	{
		public string adUnitId;
		public string currencyType;
		public float amount;


		public RewardedVideoData( string json )
		{
			var obj = MoPubMiniJSON.Json.Deserialize( json ) as Dictionary<string,object>;
			if( obj == null )
				return;

			if( obj.ContainsKey( "adUnitId" ) )
				adUnitId = obj["adUnitId"].ToString();

			if( obj.ContainsKey( "currencyType" ) )
				currencyType = obj["currencyType"].ToString();

			if( obj.ContainsKey( "amount" ) )
				amount = float.Parse( obj["amount"].ToString() );
		}


		public override string ToString ()
		{
			return string.Format( "adUnitId: {0}, currencyType: {1}, amount: {2}", adUnitId, currencyType, amount );
		}
	}



	static MoPubManager()
	{
		var type = typeof( MoPubManager );
		try
		{
			// first we see if we already exist in the scene
			var obj = FindObjectOfType( type ) as MonoBehaviour;
			if( obj != null )
				return;

			// create a new GO for our manager
			var managerGO = new GameObject( type.ToString() );
			managerGO.AddComponent( type );
			DontDestroyOnLoad( managerGO );
		}
		catch( UnityException )
		{
			Debug.LogWarning( "It looks like you have the " + type + " on a GameObject in your scene. Please remove the script from your scene." );
		}
	}



	void onAdLoaded( string height )
	{
		if( onAdLoadedEvent != null )
			onAdLoadedEvent( float.Parse( height ) );
	}


	void onAdFailed( string empty )
	{
		if( onAdFailedEvent != null )
			onAdFailedEvent();
	}


	void onAdClicked( string empty )
	{
		if ( onAdClickedEvent != null )
			onAdClickedEvent();
	}


	void onAdExpanded( string empty )
	{
		if ( onAdExpandedEvent != null )
			onAdExpandedEvent();
	}


	void onAdCollapsed( string empty )
	{
		if ( onAdCollapsedEvent != null )
			onAdCollapsedEvent();
	}


	void onInterstitialLoaded( string empty )
	{
		if( onInterstitialLoadedEvent != null )
			onInterstitialLoadedEvent();
	}


	void onInterstitialFailed( string adUnitId )
	{
		if( onInterstitialFailedEvent != null )
			onInterstitialFailedEvent();
	}


	void onInterstitialDismissed( string adUnitId )
	{
		if( onInterstitialDismissedEvent != null )
			onInterstitialDismissedEvent();
	}


	void interstitialDidExpire( string adUnitId )
	{
		if( onInterstitialExpiredEvent != null )
			onInterstitialExpiredEvent();
	}


	void onInterstitialShown( string empty )
	{
		if ( onInterstitialShownEvent != null )
			onInterstitialShownEvent();
	}


	void onInterstitialClicked( string empty )
	{
		if ( onInterstitialClickedEvent != null )
			onInterstitialClickedEvent();
	}


	#region Rewarded Videos

	void onRewardedVideoLoaded( string adUnitId )
	{
		if( onRewardedVideoLoadedEvent != null )
			onRewardedVideoLoadedEvent( adUnitId );
	}


	void onRewardedVideoFailed( string adUnitId )
	{
		if( onRewardedVideoFailedEvent != null )
			onRewardedVideoFailedEvent( adUnitId );
	}


	void onRewardedVideoExpired( string adUnitId )
	{
		if( onRewardedVideoExpiredEvent != null )
			onRewardedVideoExpiredEvent( adUnitId );
	}


	void onRewardedVideoShown( string adUnitId )
	{
		if( onRewardedVideoShownEvent != null )
			onRewardedVideoShownEvent( adUnitId );
	}


	void onRewardedVideoFailedToPlay( string adUnitId )
	{
		if( onRewardedVideoFailedToPlayEvent != null )
			onRewardedVideoFailedToPlayEvent( adUnitId );
	}


	void onRewardedVideoReceivedReward( string json )
	{
		if( onRewardedVideoReceivedRewardEvent != null )
			onRewardedVideoReceivedRewardEvent( new RewardedVideoData( json ) );
	}


	void onRewardedVideoClosed( string adUnitId )
	{
		if( onRewardedVideoClosedEvent != null )
			onRewardedVideoClosedEvent( adUnitId );
	}


	void onRewardedVideoLeavingApplication( string adUnitId )
	{
		if( onRewardedVideoLeavingApplicationEvent != null )
			onRewardedVideoLeavingApplicationEvent( adUnitId );
	}
	
	#endregion


}
#endif

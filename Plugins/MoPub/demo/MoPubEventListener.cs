using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class MoPubEventListener : MonoBehaviour
{
#if UNITY_ANDROID || UNITY_IPHONE

	void OnEnable()
	{
		// Listen to all events for illustration purposes
		MoPubManager.onAdLoadedEvent += onAdLoadedEvent;
		MoPubManager.onAdFailedEvent += onAdFailedEvent;
		MoPubManager.onAdClickedEvent += onAdClickedEvent;
		MoPubManager.onAdExpandedEvent += onAdExpandedEvent;
		MoPubManager.onAdCollapsedEvent += onAdCollapsedEvent;

		MoPubManager.onInterstitialLoadedEvent += onInterstitialLoadedEvent;
		MoPubManager.onInterstitialFailedEvent += onInterstitialFailedEvent;
		MoPubManager.onInterstitialShownEvent += onInterstitialShownEvent;
		MoPubManager.onInterstitialClickedEvent += onInterstitialClickedEvent;
		MoPubManager.onInterstitialDismissedEvent += onInterstitialDismissedEvent;
		MoPubManager.onInterstitialExpiredEvent += onInterstitialExpiredEvent;

		MoPubManager.onRewardedVideoLoadedEvent += onRewardedVideoLoadedEvent;
		MoPubManager.onRewardedVideoFailedEvent += onRewardedVideoFailedEvent;
		MoPubManager.onRewardedVideoExpiredEvent += onRewardedVideoExpiredEvent;
		MoPubManager.onRewardedVideoShownEvent += onRewardedVideoShownEvent;
		MoPubManager.onRewardedVideoFailedToPlayEvent += onRewardedVideoFailedToPlayEvent;
		MoPubManager.onRewardedVideoReceivedRewardEvent += onRewardedVideoReceivedRewardEvent;
		MoPubManager.onRewardedVideoClosedEvent += onRewardedVideoClosedEvent;
		MoPubManager.onRewardedVideoLeavingApplicationEvent += onRewardedVideoLeavingApplicationEvent;
	}


	void OnDisable()
	{
		// Remove all event handlers
		MoPubManager.onAdLoadedEvent -= onAdLoadedEvent;
		MoPubManager.onAdFailedEvent -= onAdFailedEvent;
		MoPubManager.onAdClickedEvent -= onAdClickedEvent;
		MoPubManager.onAdExpandedEvent -= onAdExpandedEvent;
		MoPubManager.onAdCollapsedEvent -= onAdCollapsedEvent;

		MoPubManager.onInterstitialLoadedEvent -= onInterstitialLoadedEvent;
		MoPubManager.onInterstitialFailedEvent -= onInterstitialFailedEvent;
		MoPubManager.onInterstitialShownEvent -= onInterstitialShownEvent;
		MoPubManager.onInterstitialClickedEvent -= onInterstitialClickedEvent;
		MoPubManager.onInterstitialDismissedEvent -= onInterstitialDismissedEvent;
		MoPubManager.onInterstitialExpiredEvent -= onInterstitialExpiredEvent;

		MoPubManager.onRewardedVideoLoadedEvent -= onRewardedVideoLoadedEvent;
		MoPubManager.onRewardedVideoFailedEvent -= onRewardedVideoFailedEvent;
		MoPubManager.onRewardedVideoExpiredEvent -= onRewardedVideoExpiredEvent;
		MoPubManager.onRewardedVideoShownEvent -= onRewardedVideoShownEvent;
		MoPubManager.onRewardedVideoFailedToPlayEvent -= onRewardedVideoFailedToPlayEvent;
		MoPubManager.onRewardedVideoReceivedRewardEvent -= onRewardedVideoReceivedRewardEvent;
		MoPubManager.onRewardedVideoClosedEvent -= onRewardedVideoClosedEvent;
		MoPubManager.onRewardedVideoLeavingApplicationEvent -= onRewardedVideoLeavingApplicationEvent;
	}



	void onAdLoadedEvent( float height )
	{
		Debug.Log( "onAdLoadedEvent. height: " + height );
	}


	void onAdFailedEvent()
	{
		Debug.Log( "onAdFailedEvent" );
	}


	void onAdClickedEvent()
	{
		Debug.Log( "onAdClickedEvent" );
	}


	void onAdExpandedEvent()
	{
		Debug.Log( "onAdExpandedEvent" );
	}


	void onAdCollapsedEvent()
	{
		Debug.Log( "onAdCollapsedEvent" );
	}


	void onInterstitialLoadedEvent()
	{
		Debug.Log( "onInterstitialLoadedEvent" );
	}


	void onInterstitialFailedEvent()
	{
		Debug.Log( "onInterstitialFailedEvent" );
	}


	void onInterstitialShownEvent()
	{
		Debug.Log( "onInterstitialShownEvent" );
	}


	void onInterstitialClickedEvent()
	{
		Debug.Log( "onInterstitialClickedEvent" );
	}


	void onInterstitialDismissedEvent()
	{
		Debug.Log( "onInterstitialDismissedEvent" );
	}


	void onInterstitialExpiredEvent()
	{
		Debug.Log( "onInterstitialExpiredEvent" );
	}


	void onRewardedVideoLoadedEvent( string adUnitId )
	{
		Debug.Log( "onRewardedVideoLoadedEvent: " + adUnitId );
	}


	void onRewardedVideoFailedEvent( string adUnitId )
	{
		Debug.Log( "onRewardedVideoFailedEvent: " + adUnitId );
	}


	void onRewardedVideoExpiredEvent( string adUnitId )
	{
		Debug.Log( "onRewardedVideoExpiredEvent: " + adUnitId );
	}


	void onRewardedVideoShownEvent( string adUnitId )
	{
		Debug.Log( "onRewardedVideoShownEvent: " + adUnitId );
	}


	void onRewardedVideoFailedToPlayEvent( string adUnitId )
	{
		Debug.Log( "onRewardedVideoFailedToPlayEvent: " + adUnitId );
	}


	void onRewardedVideoReceivedRewardEvent( MoPubManager.RewardedVideoData rewardedVideoData )
	{
		Debug.Log( "onRewardedVideoReceivedRewardEvent: " + rewardedVideoData );
	}


	void onRewardedVideoClosedEvent( string adUnitId )
	{
		Debug.Log( "onRewardedVideoClosedEvent: " + adUnitId );
	}


	void onRewardedVideoLeavingApplicationEvent( string adUnitId )
	{
		Debug.Log( "onRewardedVideoLeavingApplicationEvent: " + adUnitId );
	}

#endif
}



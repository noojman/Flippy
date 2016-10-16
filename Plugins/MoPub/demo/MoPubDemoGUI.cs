using UnityEngine;
using System.Collections.Generic;


public class MoPubDemoGUI : MonoBehaviour
{
#if UNITY_IPHONE || UNITY_ANDROID
	private string _bannerAdUnit = "23b49916add211e281c11231392559e4";
	private string _interstitialAdUnit = "3aba0056add211e281c11231392559e4";

#if UNITY_IPHONE
	private string _rewardedVideoAdUnit = "fdd35fb5d55b4ccf9ceb27c7a3926b7d";
#else
	private string _rewardedVideoAdUnit = "db2ef0eb1600433a8cdc31c75549c6b1";
#endif

	void Start()
	{
		MoPub.initializeRewardedVideo();
	}


	void OnGUI()
	{
		GUI.skin.button.margin = new RectOffset( 0, 0, 10, 0 );
		GUI.skin.button.stretchWidth = true;
		GUI.skin.button.fixedHeight = ( Screen.width >= 960 || Screen.height >= 960 ) ? 70 : 30;

		var halfWidth = Screen.width / 2;
		GUILayout.BeginArea( new Rect( 0, 0, halfWidth, Screen.height ) );
		GUILayout.BeginVertical();

		if( GUILayout.Button( "Create Banner (bottom center)" ) )
		{
			MoPub.createBanner( _bannerAdUnit, MoPubAdPosition.BottomCenter );
		}


		if( GUILayout.Button( "Create Banner (top center)" ) )
		{
			MoPub.createBanner( _bannerAdUnit, MoPubAdPosition.TopCenter );
		}


		if( GUILayout.Button( "Destroy Banner" ) )
		{
			MoPub.destroyBanner();
		}


		if( GUILayout.Button( "Show Banner" ) )
		{
			MoPub.showBanner( true );
		}


		if( GUILayout.Button( "Hide Banner" ) )
		{
			MoPub.showBanner( false );
		}



		GUILayout.EndVertical();
		GUILayout.EndArea();

		GUILayout.BeginArea( new Rect( Screen.width - halfWidth, 0, halfWidth, Screen.height ) );
		GUILayout.BeginVertical();


		if( GUILayout.Button( "Request Interstitial" ) )
		{
			MoPub.requestInterstitialAd( _interstitialAdUnit );
		}


		if( GUILayout.Button( "Show Interstitial" ) )
		{
			MoPub.showInterstitialAd( _interstitialAdUnit );
		}


		GUILayout.Space( 20 );
		if( GUILayout.Button( "Report App Open" ) )
		{
			MoPub.reportApplicationOpen();
		}


		if( GUILayout.Button( "Enable Location Support" ) )
		{
			MoPub.enableLocationSupport( true );
		}


		GUILayout.Space( 20 );
		if( GUILayout.Button( "Request Rewarded Video" ) )
		{
			MoPub.requestRewardedVideo( _rewardedVideoAdUnit );
			Debug.Log( "requesting rewarded video with ad unit: " + _rewardedVideoAdUnit );
		}


		if( GUILayout.Button( "Request Rewarded Video with Options" ) )
		{
			MoPub.requestRewardedVideo( _rewardedVideoAdUnit, getMediationSettings() );
			Debug.Log( "requesting rewarded video with ad unit: " + _rewardedVideoAdUnit );
		}

		if( GUILayout.Button( "Show Rewarded Video" ) )
		{
			MoPub.showRewardedVideo( _rewardedVideoAdUnit );
		}

		if( GUILayout.Button( "Request MPX Rewarded Video" ) )
		{
			MoPub.requestRewardedVideo( _rewardedVideoAdUnit, null, "rewarded, video, mopub", 37.7833, 122.4167 );
			Debug.Log( "requesting mpx rewarded video with ad unit: " + _rewardedVideoAdUnit );
		}

		if( GUILayout.Button( "Show MPX Rewarded Video" ) )
		{
			MoPub.showRewardedVideo( _rewardedVideoAdUnit );
		}



		GUILayout.EndVertical();
		GUILayout.EndArea();
	}


#if UNITY_IPHONE
	// mediation settings vary based on platform so we use a simple helper method to generate them here
	List<MoPubMediationSetting> getMediationSettings()
	{
		var adColonySettings = new MoPubMediationSetting( "AdColony" );
		adColonySettings.Add( "showPrePopup", true );
		adColonySettings.Add( "showPostPopup", true );

		var vungleSettings = new MoPubMediationSetting( "Vungle" );
		vungleSettings.Add( "userIdentifier", "the-user-id" );

		var mediationSettings = new List<MoPubMediationSetting>();
		mediationSettings.Add( adColonySettings );
		mediationSettings.Add( vungleSettings );

		return mediationSettings;
	}
#else
	List<MoPubMediationSetting> getMediationSettings()
	{
		var adColonySettings = new MoPubMediationSetting( "AdColony" );
		adColonySettings.Add( "withConfirmationDialog", true );
		adColonySettings.Add( "withResultsDialog", true );

		var chartboostSettings = new MoPubMediationSetting( "Chartboost" );
		chartboostSettings.Add( "customId", "the-user-id" );

		var vungleSettings = new MoPubMediationSetting( "Vungle" );
		vungleSettings.Add( "userId", "the-user-id" );
		vungleSettings.Add( "cancelDialogBody", "Cancel Body" );
		vungleSettings.Add( "cancelDialogCloseButton", "Shut it Down" );
		vungleSettings.Add( "cancelDialogKeepWatchingButton", "Watch On" );
		vungleSettings.Add( "cancelDialogTitle", "Cancel Title" );

		var mediationSettings = new List<MoPubMediationSetting>();
		mediationSettings.Add( adColonySettings );
		mediationSettings.Add( chartboostSettings );
		mediationSettings.Add( vungleSettings );

		return mediationSettings;
	}
#endif

#endif
}

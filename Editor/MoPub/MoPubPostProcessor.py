#!/usr/bin/python

import sys, os, syslog
from mod_pbxproj import XcodeProject
from mod_pbxproj import PBXBuildFile


syslog.openlog( 'MoPub' )
syslog.syslog( syslog.LOG_ALERT, '--------------- excecuting MoPub post processor ------------------' )

pathToProjectFile = sys.argv[1] + '/Unity-iPhone.xcodeproj/project.pbxproj'
pathToMoPubFolder = sys.argv[2]
project = XcodeProject.Load( pathToProjectFile )


project.add_file_if_doesnt_exist( 'System/Library/Frameworks/StoreKit.framework', tree='SDKROOT' )
project.add_file_if_doesnt_exist( 'System/Library/Frameworks/EventKit.framework', tree='SDKROOT' )
project.add_file_if_doesnt_exist( 'System/Library/Frameworks/EventKitUI.framework', tree='SDKROOT' )
project.add_file_if_doesnt_exist( 'System/Library/Frameworks/CoreTelephony.framework', tree='SDKROOT' )
project.add_file_if_doesnt_exist( 'System/Library/Frameworks/CoreImage.framework', tree='SDKROOT' )
project.add_file_if_doesnt_exist( 'System/Library/Frameworks/CoreBluetooth.framework', tree='SDKROOT' )
project.add_file_if_doesnt_exist( 'System/Library/Frameworks/Security.framework', tree='SDKROOT' )
project.add_file_if_doesnt_exist( 'System/Library/Frameworks/AdSupport.framework', tree='SDKROOT', weak=True )

# AdMob
project.add_file_if_doesnt_exist( 'System/Library/Frameworks/MessageUI.framework', tree='SDKROOT' )

# Millennial
project.add_file_if_doesnt_exist( 'System/Library/Frameworks/MediaPlayer.framework', tree='SDKROOT' )
project.add_file_if_doesnt_exist( 'System/Library/Frameworks/PassKit.framework', tree='SDKROOT' )
project.add_file_if_doesnt_exist( 'System/Library/Frameworks/Social.framework', tree='SDKROOT' )
project.add_file_if_doesnt_exist( 'System/Library/Frameworks/MobileCoreServices.framework', tree='SDKROOT' )

# Vungle
project.add_file_if_doesnt_exist( 'usr/lib/libsqlite3.dylib', tree='SDKROOT' )
project.add_file_if_doesnt_exist( 'usr/lib/libz.dylib', tree='SDKROOT' )
project.add_file_if_doesnt_exist( 'usr/lib/libxml2.dylib', tree='SDKROOT' )



# add all source files and frameworks
project.add_other_ldflags( '-ObjC' )
project.add_folder( os.path.join( pathToMoPubFolder, 'NativeCode' ), excludes=["^.*\.meta$", "^.*\.txt$"] )


# files that require ARC need to be handled here
filesThatRequireArc = [ 'FacebookNativeAdAdapter.m', 'MPMillennialBannerCustomEvent.m', 'UnityAdsMopubEvent.m', 'MPVungleRouter.m' ]
for arcFile in filesThatRequireArc:
    temp = project.get_files_by_name( arcFile )
    if temp:
        buildFiles = project.get_build_files( temp[0].id )

        if buildFiles and len( buildFiles ) > 0:
            for buildFile in buildFiles:
                syslog.syslog( syslog.LOG_ALERT, 'swapping ARC flag on for file: ' + temp[0].get( 'name' ) )
                buildFile.add_compiler_flag( '-fobjc-arc' )

    else:
        syslog.syslog( syslog.LOG_ALERT, 'could not find file to switch compile type to ARC' )


if project.modified:
    syslog.syslog( syslog.LOG_ALERT, 'saving Xcode project file modifications' )
    project.save()

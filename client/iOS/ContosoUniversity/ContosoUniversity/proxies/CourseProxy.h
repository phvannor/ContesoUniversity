//
//  CourseProxy.h
//  ContosoUniversity
//
//  Created by Shrirang on 7/24/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <WindowsAzureMobileServices/WindowsAzureMobileServices.h>

@interface CourseProxy : NSObject

- (id) initWithMobileAppClient:(MSClient *)client;

@end

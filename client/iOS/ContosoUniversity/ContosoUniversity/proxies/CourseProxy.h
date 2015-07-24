//
//  CourseProxy.h
//  ContosoUniversity
//
//  Created by Shrirang on 7/24/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <WindowsAzureMobileServices/WindowsAzureMobileServices.h>
#import "Courses.h"

@interface CourseProxy : NSObject

@property (nonatomic) MSClient *client;

@property (nonatomic) MSTable *table;

- (instancetype)initWithMobileAppClient:(MSClient *)client tableName:(NSString *)tableName;

- (void)insert:(Courses *)course completion:(MSSyncItemBlock)completion;

- (void)pullData:(MSSyncBlock)completion;

@end

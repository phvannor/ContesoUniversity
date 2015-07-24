//
//  CoursesModel.m
//  ContosoUniversity
//
//  Created by Shrirang on 7/24/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#import "CourseModel.h"

@implementation CourseModel

- (NSDictionary *)dictionary {
    
    return @{
                @"departmentID" : [NSNumber numberWithInteger:self.departmentID],
                @"credits" : [NSNumber numberWithInteger:self.credits],
                @"title" : self.title,
                @"id" : self.id
            };
}

@end
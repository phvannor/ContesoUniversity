//
//  CoursesModel.h
//  ContosoUniversity
//
//  Created by Shrirang on 7/24/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface CourseModel : NSObject

@property (nonatomic) NSInteger departmentID;

@property (nonatomic) NSInteger credits;

@property (nonatomic) NSString *title;

@property (nonatomic) NSString *id;

- (NSDictionary *)dictionary;

@end

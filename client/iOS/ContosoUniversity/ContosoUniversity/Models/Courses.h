//
//  Courses.h
//  ContosoUniversity
//
//  Created by Phillip Van Nortwick on 7/24/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <CoreData/CoreData.h>


@interface Courses : NSManagedObject

@property (nonatomic, retain) NSNumber * credits;
@property (nonatomic, retain) NSNumber * departmentID;
@property (nonatomic, retain) NSString * id;
@property (nonatomic, retain) NSString * title;

@end

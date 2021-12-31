#import <Foundation/Foundation.h>

extern "C" void impact(int style) {
    UIImpactFeedbackGenerator *generator = [[UIImpactFeedbackGenerator alloc] initWithStyle: (UIImpactFeedbackStyle)style];
    [generator impactOccurred];
    generator = NULL;
}

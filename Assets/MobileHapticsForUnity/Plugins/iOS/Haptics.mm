#import <Foundation/Foundation.h>
#import <CoreHaptics/CoreHaptics.h>

extern "C" {
    void impact(int style) {
        UIImpactFeedbackGenerator *generator = [[UIImpactFeedbackGenerator alloc] initWithStyle: (UIImpactFeedbackStyle)style];
        [generator impactOccurred];
        generator = NULL;
    }

    __strong static CHHapticEngine *hapticEngine;

    void impactWith(float intensity, float sharpness, float duration, float sustained) {
        NSLog(@"intensity %f, sharpness %f, duration %f, sustained %f", intensity, sharpness, duration, sustained);
        hapticEngine = [[CHHapticEngine alloc] initAndReturnError: nil];
        
        CHHapticEventParameter *intensityParam = [[CHHapticEventParameter alloc] initWithParameterID: CHHapticEventParameterIDHapticIntensity value: intensity];
        CHHapticEventParameter *sharpnessParam = [[CHHapticEventParameter alloc] initWithParameterID: CHHapticEventParameterIDHapticSharpness value: sharpness];
        CHHapticEventParameter *sustainedParam = [[CHHapticEventParameter alloc] initWithParameterID: CHHapticEventParameterIDSustained value: sustained];

        CHHapticEvent *event = [[CHHapticEvent alloc] initWithEventType: CHHapticEventTypeHapticContinuous parameters:@[intensityParam, sharpnessParam, sustainedParam] relativeTime: 0 duration: duration];
        CHHapticPattern *pattern = [[CHHapticPattern alloc] initWithEvents: @[event] parameterCurves: @[] error: nil];
        
        id player = [hapticEngine createPlayerWithPattern: pattern error: nil];
        
        [hapticEngine startAndReturnError: nil];
        [player startAtTime:0 error: nil];
    }
}

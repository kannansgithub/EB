'use client';
import Autoplay from 'embla-carousel-autoplay';
import { Carousel, CarouselContent, CarouselItem } from './ui/carousel';
import { Card, CardContent } from './ui/card';

const LoginPageCarousel = () => {
  return (
    <div className="mx-5 w-full flex items-center justify-center">
      <Carousel
        opts={{
          align: 'end',
        }}
        plugins={[
          Autoplay({
            delay: 2000,
          }),
        ]}
        className="w-full px-20 max-h-50"
      >
        <CarouselContent>
          {Array.from({ length: 5 }).map((_, index) => (
            <CarouselItem key={index} className="md:basis-1/2 lg:basis-1/2">
              <div className="p-1">
                <Card>
                  <CardContent className="items-center justify-center p-6">
                    <span className="text-sm font-semibold">
                      {index + 1} Hello Test Message sdkfjhdskfhsdkhfsdhfkjshd
                      sdkfhsdkjhf skdhfdskjhf kdshfskdhf khfdskhsdk dfjgdfljg
                      ljgldjfg ljdfglkdfjgfd{' '}
                    </span>
                  </CardContent>
                </Card>
              </div>
            </CarouselItem>
          ))}
        </CarouselContent>
      </Carousel>
    </div>
  );
};

export default LoginPageCarousel;

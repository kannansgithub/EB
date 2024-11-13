// import { GaugeComponent } from 'react-gauge-component';
// const Gauge = ({value}:{value: number}) => {
//   return (
//     <GaugeComponent
//       type="semicircle"
//       arc={{
//         width: 0.2,
//         padding: 0.005,
//         cornerRadius: 1,
//         // gradient: true,
//         subArcs: [
//           {
//             limit: 15,
//             color: '#EA4228',
//             showTick: true,
//             tooltip: {
//               text: 'Too low temperature!',
//             },
//             onClick: () => console.log('AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA'),
//             onMouseMove: () => console.log('BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB'),
//             onMouseLeave: () => console.log('CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC'),
//           },
//           {
//             limit: 17,
//             color: '#F5CD19',
//             showTick: true,
//             tooltip: {
//               text: 'Low temperature!',
//             },
//           },
//           {
//             limit: 28,
//             color: '#5BE12C',
//             showTick: true,
//             tooltip: {
//               text: 'OK temperature!',
//             },
//           },
//           {
//             limit: 30,
//             color: '#F5CD19',
//             showTick: true,
//             tooltip: {
//               text: 'High temperature!',
//             },
//           },
//           {
//             color: '#EA4228',
//             tooltip: {
//               text: 'Too high temperature!',
//             },
//           },
//         ],
//       }}
//       pointer={{
//         color: '#345243',
//         length: 0.8,
//         width: 15,
//         // elastic: true,
//       }}
//       labels={{
//         valueLabel: { formatTextValue: (value) => value + 'ºC' },
//         tickLabels: {
//           type: 'outer',
//           defaultTickValueConfig: {
//             formatTextValue: (value: unknown) => value + 'ºC',
//             style: { fontSize: 10 },
//           },
//           ticks: [{ value: 13 }, { value: 22.5 }, { value: 32 }],
//         },
//       }}
//       value={value}
//       minValue={10}
//       maxValue={35}
//     />
//   );
// };

// export default Gauge;

export const Gauge = ({
  value,
  size = 'small',
  showValue = true,
  color = 'text-[hsla(131,41%,46%,1)]',
  bgcolor = 'text-[#333]',
}: {
  value: number;
  size: 'small' | 'medium' | 'large';
  showValue: boolean;
  color?: string;
  bgcolor?: string;
}) => {
  const circumference = 332; //2 * Math.PI * 53; // 2 * pi * radius
  const valueInCircumference = (value / 100) * circumference;
  const strokeDasharray = `${circumference} ${circumference}`;
  const initialOffset = circumference;
  const strokeDashoffset = initialOffset - valueInCircumference;

  const sizes = {
    small: {
      width: '36',
      height: '36',
      textSize: 'text-xs',
    },
    medium: {
      width: '72',
      height: '72',
      textSize: 'text-lg',
    },
    large: {
      width: '144',
      height: '144',
      textSize: 'text-3xl',
    },
  };

  return (
    <div className="flex flex-col items-center justify-center relative">
      <svg
        fill="none"
        shapeRendering="crispEdges"
        height={sizes[size].height}
        width={sizes[size].width}
        viewBox="0 0 120 120"
        strokeWidth="2"
        className="transform -rotate-90"
      >
        <circle
          className={`${bgcolor}`}
          strokeWidth="12"
          stroke="currentColor"
          fill="transparent"
          shapeRendering="geometricPrecision"
          r="53"
          cx="60"
          cy="60"
        />
        <circle
          className={`animate-gauge_fill ${color}`}
          strokeWidth="12"
          strokeDasharray={strokeDasharray}
          strokeDashoffset={initialOffset}
          shapeRendering="geometricPrecision"
          strokeLinecap="round"
          stroke="currentColor"
          fill="transparent"
          r="53"
          cx="60"
          cy="60"
          style={{
            strokeDashoffset: strokeDashoffset,
            transition: 'stroke-dasharray 1s ease 0s,stroke 1s ease 0s',
          }}
        />
      </svg>
      {showValue ? (
        <div className="absolute flex opacity-0 animate-gauge_fadeIn">
          <p className={`text-gray-100 ${sizes[size].textSize}`}>{value}</p>
        </div>
      ) : null}
    </div>
  );
};

// From: https://thebookofshaders.com/05/
// Author: Inigo Quiles
// Title: Expo

#ifdef GL_ES
precision mediump float;
#endif

#define PI 3.14159265359

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;

//space over f(x)-0.02 - space over f(x)+0.02
float plot(vec2 st, float pct){
  return  smoothstep( pct-0.02, pct, st.y) -
          smoothstep( pct, pct+0.02, st.y);
}

void main() {
    vec2 st = gl_FragCoord.xy/u_resolution;


    float exponent = 20.0;
    //raising f to the power of exponent
    //float y = pow(st.x, exponent);
    
    //ln of x + 1
    //float y = log(st.x + 1.0);

    //e^x
    //float y = exp( 5.0 * st.x - 3.0);

    //step function => if st.x is greater than 0.5, return 1.0, else return 0.0
    //float y = step(0.5, st.x);

    //smoothstep function => smooth interpolation between 0.1 and 0.9
    //(starting from 0.1 till 0.9 raises smoothly)
    //float y = smoothstep(0.1, 0.9, st.x);

    //how we draw the function in line 17 
    //
    //I.E. let's consider the power example,
    //for a pixel with x = 0.5 if it's y value is 0.48 < pixel.y = pow(x,exponent) < 0.52 it will be drawn
    float y = smoothstep(0.48,0.5,st.x) - smoothstep(0.5,0.52,st.x);

    vec3 color = vec3(y);

    float pct = plot(st,y);
    color = (1.0-pct)*color+pct*vec3(0.0,1.0,0.0);

    gl_FragColor = vec4(color,1.0);
}
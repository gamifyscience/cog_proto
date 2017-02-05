//
//  Shader.fsh
//  cog_proto
//
//  Created by Admin on 1/8/17.
//  Copyright © 2017 Gamify. All rights reserved.
//

varying lowp vec4 colorVarying;

void main()
{
    gl_FragColor = colorVarying;
}

using System.ComponentModel;

namespace Model.Sections
{
    public enum TempoChangeString
    {
        None,
        // acceleration
        accelerando,
        [Description("accel.")]
        accel,
        affrettando,
        incalzando,
        [Description("più mosso")]
        piùmosso,
        [Description("poco più")]
        pocopiu,
        stringendo,
        // retardation
        allargando,
        calando,
        largando,
        [Description("meno mosso")]
        menomosso,
        piulento,
        [Description("poco meno")]
        pocomeno,
        rallentando,
        ritardando,
        [Description("rit.")]
        rit,
        ritenente,
        ritenuto,
        slentando,
        strasciando,
        // free
        [Description("a bene placito")]
        abeneplacito,
        [Description("a capriccio")]
        acapriccio,
        [Description("a piacere")]
        apiacere,
        [Description("a piacimento")]
        apiacimento,
        [Description("a suo arbitrio")]
        asuoarbitrio,
        commodo,
        placito,
        [Description("ad libitum")]
        adlibitum,
        [Description("collaparte")]
        collaparte,
        rubato,
        [Description("senza misura")]
        senzamisura,
        [Description("senza tempo")]
        senzatempo,
        suivez,
        // return
        [Description("a battuta")]
        abattuta,
        [Description("a tempo")]
        atempo,
        [Description("al rigore di tempo")]
        alrigoreditempo,
        misurato,
        [Description("tempo primo")]
        tempoprimo,
        [Description("tempo I")]
        tempoi,
        // misc
        [Description("alla breve")]
        allebreve,
        [Description("doppio movimento")]
        doppiomovimento
    }
}
